﻿using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> ToList();
        Task<Movie> Find(Expression<Func<Movie,bool>> predicate);
        Task Insert(Movie obj);
        Task Update(Movie obj);
        Task Delete(Movie obj);
    }
}