using System.Text.Json.Serialization;
using ContactApp.Contact.API.Extensions;
using ContactApp.Contact.API.Middlewares;
using ContactApp.Contact.Application.Extensions;
using ContactApp.Contact.Persistence.Context;
using ContactApp.Contact.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddPersistenceRegistrations(configuration: builder.Configuration);
builder.Services.AddApplicationRegistrations();

var app = builder.Build();

app.ApplyMigration<ApplicationDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();