using CoreStreet;
using CoreStreet.AutoMapper;
using CoreStreet.Repository;
using EFDataAcces.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StreetContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IGroupRepository, GroupRepositoryMock>();
builder.Services.AddScoped<ISpotRepository, SpotRepositoryMock>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<SeedData>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}else
{
    // For mobile apps, allow http traffic.
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();