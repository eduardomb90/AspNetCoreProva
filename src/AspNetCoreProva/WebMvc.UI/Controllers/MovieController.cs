using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.UI.Configuration;
using WebMvc.UI.Models;

namespace WebMvc.UI.Controllers
{
    public class MovieController : MainController
    {
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, IMapper mapper, IMovieService movieService)
        : base(mapper, movieService)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var movie = await _movieService.ToList();
            var movieViewModel = _mapper.Map<IEnumerable<MovieViewModel>>(movie);

            return View(movieViewModel);
        }
    }
}
