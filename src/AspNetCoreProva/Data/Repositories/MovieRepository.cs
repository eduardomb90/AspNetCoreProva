using Application.Domain.Entities;
using Application.Interfaces.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Movie>> FilterMovies(Expression<Func<Movie, bool>> predicate)
        {
            return await _context.Movies.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.Include(x => x.Genre).ToListAsync();
        }

        public async Task<Movie> GetById(Guid id)
        {
            return await _context.Movies.Include(x => x.Genre).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
