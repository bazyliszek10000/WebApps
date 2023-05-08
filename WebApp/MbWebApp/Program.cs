using System.Net.Mime;
using System.Reflection;
using FluentValidation;
using MbDB.Entities;
using MbWebApp.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;

string allowSpecificOrigins = "AllowSpecificOrigins";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<MbDbContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("MbDatabase")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost/") // policy.WithOrigins("http://localhost:3000/")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var votingPollAssembly = typeof(MbVotingPoll.Commands.CreateVoter.CreateVoterCommandHandler).Assembly;
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(votingPollAssembly));
builder.Services.AddValidatorsFromAssembly(votingPollAssembly);

var storeAssembly = typeof(MbStore.Queries.GetOrders.GetOrdersQuery).Assembly;
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(storeAssembly));
builder.Services.AddValidatorsFromAssembly(storeAssembly);

builder.Services.AddControllers();
builder.Services.AddDbContext<MbDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();