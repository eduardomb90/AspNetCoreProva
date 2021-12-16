using Application.Domain.Entities;
using Application.Interfaces.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

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

        public async Task<PagedViewModel<Movie>> Paginacao(int page, int size, string query = null)
        {
            IPagedList<Movie> movieList;
            
            if (!String.IsNullOrEmpty(query))
            movieList = await _context.Movies.Include(x => x.Genre).Where(x => x.Title.Contains(query) || x.Genre.Name.Contains(query))
                    .AsNoTracking().ToPagedListAsync(page, size);
            else
                movieList = await _context.Movies.Include(x => x.Genre).AsNoTracking().ToPagedListAsync(page, size);

            return new PagedViewModel<Movie>()
            {
                List = movieList.ToList(),
                PageIndex = page,
                PageSize = size,
                Query = query,
                TotalResult = movieList.TotalItemCount
            };
        }
    }
}
