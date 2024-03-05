using CRM.api.Services;
using CRM.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging
    .ClearProviders()
    .AddConfiguration(builder.Configuration.GetSection("Logging"));


builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddDbContext<CRMDbContext>(opt =>
    opt.UseSqlServer(
            builder.Configuration.GetConnectionString("CRMdb"),
            config => config.EnableRetryOnFailure()
        )
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<CRMDbContext>();
    context?.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(o => true));
app.UseForwardedHeaders();

app.UseAuthorization();

app.MapControllers();

app.Run();
