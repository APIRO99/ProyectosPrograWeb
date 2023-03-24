using api.Services;
using api.Context;
using ClasificacionPeliculasModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDatabaseService<Category, int>>(s => new CategoryService(new MoviesContext()));
builder.Services.AddSingleton<IDatabaseService<PersonalInformation, int>>(s => new PersonalInformationService(new MoviesContext()));
builder.Services.AddSingleton<IDatabaseService<Vote, int>>(s => new VoteService(new MoviesContext()));
builder.Services.AddSingleton<IMoviesService>(s => new MovieService(new MoviesContext()));
builder.Services.AddSingleton<IGeographicService>(s => new GeographicService(new MoviesContext()));

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
