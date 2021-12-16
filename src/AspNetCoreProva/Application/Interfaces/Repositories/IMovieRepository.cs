using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<Movie> GetById(Guid id);
        Task<IEnumerable<Movie>> GetAllMovies();

        Task<IEnumerable<Movie>> FilterMovies(Expression<Func<Movie, bool>> predicate);
    }
}
