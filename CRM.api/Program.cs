var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging
    .ClearProviders()
    .AddConfiguration(builder.Configuration.GetSection("Logging"));


builder.Services.AddControllers();

builder.Services.AddDbContext<WLSSDbContext>(opt =>
    opt.UseSqlServer(
            builder.Configuration.GetConnectionString("WLSSCoreDatabase"),
            config => config.EnableRetryOnFailure()
        )
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
