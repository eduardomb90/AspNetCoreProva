using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Data.Context;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InversionOfControl.DependencyInjection
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<MovieDbContext>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieService, MovieService>();

            return services;
        }
    }
}
