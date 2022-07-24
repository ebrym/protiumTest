using Autofac;
using Autofac.Extensions.DependencyInjection;
using Protium.Data;
using Protium.Repository.AutofacModule;
using Microsoft.EntityFrameworkCore;
using Protium.Repository.Interface;
using Protium.Repository.Repository;
using Protium.Api.Mapping;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("protium"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument(x =>
{
    x.GenerateXmlObjects = true;
    x.GenerateEnumMappingDescription = true;
    x.DocumentName = "Protium Shipment Api";
    x.Title = "Protium Shipment";
    x.Description = "Protium Shipment Api";
   
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        //builder.RegisterType(typeof(Repository<>)).As(typeof(IRepository<>));
        builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();


        builder.RegisterModule(new AutofacRepoModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
