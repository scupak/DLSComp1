

using LoadBalancer.LoadBalancer;
using LoadBalancer.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILoadBalancerStrategy, RoundRobinStrategy>();
builder.Services.AddScoped<ILoadBalancer, LoadBalancer.LoadBalancer.LoadBalancer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config => config.AllowAnyOrigin());
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();