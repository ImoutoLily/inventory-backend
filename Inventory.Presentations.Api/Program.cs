using Inventory.Presentations.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAppsettings(builder.Configuration)
    .AddInventoryContext(builder.Environment)
    .AddIdentity()
    .AddGateways()
    .AddUseCases()
    .AddJwt();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            Description = "JWT Authorization header using Bearer scheme."
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            { 
                new OpenApiSecurityScheme 
                { 
                    Reference = new OpenApiReference 
                    { 
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer" 
                    } 
                },
                Array.Empty<string>()
            } 
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();