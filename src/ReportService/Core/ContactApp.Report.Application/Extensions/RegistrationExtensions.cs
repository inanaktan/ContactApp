using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ContactApp.Report.Application.Consumers;
using ContactApp.Report.Domain.Messages;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactApp.Report.Application.Extensions;

public static class RegistrationExtensions
{
    public static void AddApplicationRegistrations(this IServiceCollection services, IConfiguration configuration)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(assm);
        services.AddValidatorsFromAssembly(assm);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMassTransit(configuration: configuration);
    }

    public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
         services.AddMassTransit(x =>
                {
                    x.AddConsumer<PreparedContactLocationReportMessageConsumer>();

                    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        cfg.ReceiveEndpoint(nameof(PreparedContactLocationReportMessage), ep =>
                        {
                            ep.ConfigureConsumer<PreparedContactLocationReportMessageConsumer>(provider);
                        });
                    }));
                 });

                //  services.AddTransient<PreparedContactLocationReportMessageConsumer>();
        
        // services.AddMassTransit(x =>
        // {
        //     x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        //     {
        //         cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
        //         {
        //             h.Username("guest");
        //             h.Password("guest");
        //         });
        //         // cfg.ReceiveEndpoint("cart", ep =>
        //         // {
        //         //     ep.ConfigureConsumer<ShoppingCartConsumer>(provider);
        //         // });
        //     }));
        // });

        //         services.AddMassTransit(x =>
        //         {
        //             x.AddConsumer<ShoppingCartConsumer>();

        //             x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        //             {
        //                 cfg.Host(new Uri("rabbitmq://localhost"), h =>
        //                 {
        //                     h.Username("guest");
        //                     h.Password("guest");
        //                 });
        //                 cfg.ReceiveEndpoint("cart", ep =>
        //                 {
        //                     ep.PrefetchCount = 16;
        //                     ep.UseMessageRetry(r => r.Interval(2, 100));
        //                     ep.ConfigureConsumer<ShoppingCartConsumer>(provider);
        //                 });
        //             }));
        //          });
    }
}

