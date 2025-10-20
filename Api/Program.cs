using Api.Configurations;
using Api.Data;
using Api.Domain;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Services;
using Api.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

var connectionString = builder.Configuration.GetConnectionString("Postgres")!;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IURLService, URLService>();
builder.Services.AddSingleton<IURLShortener, URLShorteningService>();
builder.Services.AddSingleton<IJwtProvider, JwtProvider>();
builder.Services.AddControllers();

var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;
builder.Services.AddApiAuthentication(jwtOptions);
builder.Services.AddRepositories();
builder.Services.AddValidation();
builder.Services.AddLogging();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MigrateDatabase();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
