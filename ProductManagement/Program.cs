using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using ProductManagement.Middleware;
using Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Application.Products.Commands.CreateProduct;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Common.Mappings;



var builder = WebApplication.CreateBuilder(args);

// Add configuration for ADFS
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd")); 

builder.Services.AddAuthentication("Dummy")
    .AddScheme<AuthenticationSchemeOptions, ProductManagement.Authentication.DummyAuthenticationHandler>("Dummy", options => { });


// Add application & infrastructure services
builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MappingProfile).Assembly);
});

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
