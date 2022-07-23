using Autofac;
using Autofac.Extensions.DependencyInjection;
using Protium.Data;
using Protium.Repository.AutofacModule;
using Microsoft.EntityFrameworkCore;
using Protium.Repository.Interface;
using Protium.Repository.Repository;
using Protium.Api.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("protium"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
