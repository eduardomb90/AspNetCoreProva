using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<Movie> GetById(Guid id);
        Task<IEnumerable<Movie>> GetAllMovies();
    }
}
