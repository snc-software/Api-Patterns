using ApiPatterns.Core.Services.Data.Users;
using ApiPatterns.Core.Services.Data.Users.Interfaces;
using ApiPatterns.Core.Services.Logic;
using ApiPatterns.Core.Services.Logic.Interfaces;
using Controller.Api.Middleware;
using Controller.Api.ServiceInterface.Queries.Users;
using Controller.Api.ServiceModel.Mappings;
using Controller.Api.ServiceModel.Mappings.Interfaces;
using HashidsNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddMediatR(typeof(GetUsersQuery));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddSingleton<IRandomProvider, RandomProvider>();
builder.Services.AddSingleton<IUserRetriever, UserRetriever>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

var hashids = new Hashids("MySuperSecretSalt", 8);
builder.Services.AddSingleton<IHashids>(_ => hashids);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseAuthorization();
app.MapControllers();


app.Run();