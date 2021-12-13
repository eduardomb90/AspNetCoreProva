using Application.Domain.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;        
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Movie>> ToList()
        {
            return await _movieRepository.ToList();
        }

        public async Task<Movie> Find(Expression<Func<Movie, bool>> predicate)
        {
            return await _movieRepository.Find(predicate);
        }

        public async Task Insert(Movie obj)
        {
            await _movieRepository.Insert(obj);
        }

        public async Task Update(Movie obj)
        {
            var movie = await Find(movie => movie.Id == obj.Id);
            if (movie == null) return;

            await _movieRepository.Update(movie);
        }

        public async Task Delete(Movie obj)
        {
            var movie = await Find(movie => movie.Id == obj.Id);
            if (movie == null) return;

            await _movieRepository.Delete(movie);
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _genreRepository.ToList();
        }

        public async Task<Genre> GetGenre(Expression<Func<Genre, bool>> predicate)
        {
            return await _genreRepository.Find(predicate);
        }
    }
}
