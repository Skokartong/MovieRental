using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using DotNetEnv;
using MovieRental.Data.Repos.IRepos;
using MovieRental.Data.Repos;
using MovieRental.Services.IServices;
using MovieRental.Services;

var builder = WebApplication.CreateBuilder(args);

// Loading Environment variables
Env.Load();

// Adding DbContext in our DI-container 
builder.Services.AddDbContext<MovieRentalContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding the repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

//Adding the services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IMovieService, MovieService>();

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
