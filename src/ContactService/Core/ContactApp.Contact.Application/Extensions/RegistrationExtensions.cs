using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ContactApp.Contact.Application.Consumers;
using ContactApp.Contact.Domain.Message;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ContactApp.Contact.Application.Extensions;

public static class RegistrationExtensions
{
    public static void AddApplicationRegistrations(this IServiceCollection services)
    {

        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(assm);
        services.AddValidatorsFromAssembly(assm);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMassTransit();
    }

    public static void AddMassTransit(this IServiceCollection services)
    {
        // services.AddMassTransit(x =>
        // {

        //     x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        //     {
        //         cfg.ReceiveEndpoint(nameof(PrepareLocationReportMessage), ep =>
        //         {
        //             ep.ConfigureConsumer<PrepareLocationReportMessageConsumer>(provider);
        //         });

        //         cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
        //         {
        //             h.Username("guest");
        //             h.Password("guest");
        //         });
        //     }));
        // });

        // services.AddScoped<PrepareLocationReportMessageConsumer>();

                services.AddMassTransit(x =>
                {
                    x.AddConsumer<PrepareLocationReportMessageConsumer>();

                    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        cfg.ReceiveEndpoint(nameof(PrepareLocationReportMessage), ep =>
                        {
                            ep.ConfigureConsumer<PrepareLocationReportMessageConsumer>(provider);
                        });
                    }));
                 });

                //  services.AddTransient<PrepareLocationReportMessageConsumer>();
    }
}
