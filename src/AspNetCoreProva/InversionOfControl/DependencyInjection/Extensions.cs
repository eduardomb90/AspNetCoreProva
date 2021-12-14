using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Data.Context;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InversionOfControl.DependencyInjection
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MovieDbContext>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<INotifierService, NotifierService>();

            services.AddDbContext<MovieDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("MovieDbContext")));

            return services;
        }
    }
}
