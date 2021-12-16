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
        private readonly INotifierService _notifierService;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository, INotifierService notifierService)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _notifierService = notifierService;
        }

        public async Task<IEnumerable<Movie>> ToList()
        {
            return await _movieRepository.ToList();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }

        public async Task<Movie> Find(Expression<Func<Movie, bool>> predicate)
        {
            return await _movieRepository.Find(predicate);
        }

        public async Task<Movie> GetById(Guid id)
        {
            return await _movieRepository.GetById(id);
        }

        public async Task<IEnumerable<Movie>> FilterMovies(Expression<Func<Movie, bool>> predicate)
        {
            return await _movieRepository.FilterMovies(predicate);
        }

        public async Task Insert(Movie obj)
        {
            if (_movieRepository.Find(x => x.Title.Equals(obj.Title) && x.ReleaseDate == obj.ReleaseDate).Result != null)
            {
                _notifierService.AddError("O filme já existe!");
                return;
            }
            
            await _movieRepository.Insert(obj);
            await _movieRepository.SaveChanges();
        }

        public async Task Update(Movie obj)
        {
            //var movie = await Find(movie => movie.Id == obj.Id);
            
            //if (movie == null)
            //{
            //    _notifierService.AddError("Filme não encontrado");
            //    return;
            //}

            await _movieRepository.Update(obj);
            await _movieRepository.SaveChanges();
        }

        public async Task Delete(Movie obj)
        {
            //var movie = await Find(movie => movie.Id == obj.Id);
            //if (movie == null)
            //{
            //    _notifierService.AddError("Filme não encontrado");
            //    return;
            //}

            await _movieRepository.Delete(obj);
            await _movieRepository.SaveChanges();
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _genreRepository.ToList();
        }

        public async Task<Genre> GetGenre(Expression<Func<Genre, bool>> predicate)
        {
            return await _genreRepository.Find(predicate);
        }

        public async Task<IEnumerable<Genre>> GetGenreOrdered()
        {
            return await _genreRepository.GetOrdered();
        }

        public async Task<Genre> GetGenreByName(string name)
        {
            return await _genreRepository.GetGenreByName(name);
        }

        public Task<PagedViewModel<Movie>> Paginacao(int page = 1, int size = 5, string query = null)
        {
            return _movieRepository.Paginacao(page, size, query);
        }
    }
}
