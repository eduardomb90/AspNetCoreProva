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
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieDbContext context) : base(context)
        {
        }

        public async Task<Genre> GetGenreByName(string name)
        {
            return await _context.Genres.Include("Movies").SingleAsync(g => g.Name == name);
        }

        public async Task<IEnumerable<Genre>> GetOrdered()
        {
            var genres = await _context.Genres.OrderBy(x => x.Name).ToListAsync();
            
            return genres;
        }
    }
}
