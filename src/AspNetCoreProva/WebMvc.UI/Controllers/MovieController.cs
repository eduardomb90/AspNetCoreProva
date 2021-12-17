using Application.Domain.Entities;
using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.UI.Configuration;
using WebMvc.UI.Models;

namespace WebMvc.UI.Controllers
{
    public class MovieController : MainController
    {
        private readonly ILogger<MovieController> _logger;
        protected readonly IMovieService _movieService;
        protected readonly MovieValidation _movieValidation;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService,
                                IMapper mapper, INotifierService notifierService, MovieValidation movieValidation)
        : base(mapper, notifierService)
        {
            _logger = logger;
            _movieService = movieService;
            _movieValidation = movieValidation;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1, int size = 5, string query = default, string queryGenre = default)
        {
            var genreList = _mapper.Map<IEnumerable<GenreViewModel>>(await _movieService.GetAllGenres());
            ViewBag.GenreList = new SelectList(genreList, "Name", "Name");
            
            TempData["Query"] = query;
            
            var movie = await _movieService.Paginacao(page, size, query, queryGenre);
            
            return View(_mapper.Map<PagedViewModel<MovieViewModel>>(movie));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var screenViewModel = new MovieViewModel();
            await MappingListGeneros(screenViewModel);
            
            return View(screenViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(await MappingListGeneros(viewModel));

            var path = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageUpload?.FileName);

            if(UploadFile(viewModel.ImageUpload, path).Result)
            {
                viewModel.ImagePath = path;
            }

            await _movieService.Insert(_mapper.Map<Movie>(viewModel));

            if (!ValidOperation()) return View(await MappingListGeneros(viewModel));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieService.GetById(id);

            return View(_mapper.Map<MovieViewModel>(movie));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(Guid id)
        {
            var movie = await _movieService.GetById(id);

            if (movie == null) return NotFound();

            var viewModel = _mapper.Map<MovieViewModel>(movie);

            await MappingListGeneros(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(await MappingListGeneros(viewModel));

            var result = await _movieValidation.ValidateAsync(viewModel);

            if (!result.IsValid) 
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                
                return View(await MappingListGeneros(viewModel));
            }
            
            var path = Guid.NewGuid() + Path.GetExtension(viewModel.ImageUpload?.FileName);

            if (UploadFile(viewModel.ImageUpload, path).Result)
            {
                //if(viewModel.ImagePath != null)
                //{

                //}
                
                viewModel.ImagePath = path;
            }

            await _movieService.Update(_mapper.Map<Movie>(viewModel));

            if (!ValidOperation()) return View(await MappingListGeneros(viewModel));

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieService.GetById(id);

            if (movie == null) return NotFound();

            var viewModel = _mapper.Map<MovieViewModel>(movie);

            return View(viewModel);
        }

        [HttpPost(), ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(MovieViewModel viewModel)
        { 
            await _movieService.Delete(_mapper.Map<Movie>(viewModel));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GenreMenu()
        {
            var genres = await _movieService.GetAllGenres();            
            var viewModel = _mapper.Map<IEnumerable<GenreViewModel>>(genres);

            return View(viewModel);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Browse(string genre = "Action")
        {
            var genreModel = await _movieService.GetGenreByName(genre);
            var viewModel = _mapper.Map<GenreViewModel>(genreModel);

            return View(viewModel);
        }









        // METODOS PRIVADOS
        private async Task<MovieViewModel> MappingListGeneros(MovieViewModel viewModel)
        {
            viewModel.Genres = _mapper.Map<IEnumerable<GenreViewModel>>(await _movieService.GetAllGenres());
            return viewModel;
        }
        private async Task<bool> UploadFile(IFormFile imageUpload, string imgPath)
        {
            if(imageUpload == null /*|| imageUpload?.Length == 0*/)  return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", imgPath);

            if (System.IO.File.Exists(path)) return false;

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageUpload.CopyToAsync(stream);
            }

            return true;
        }
    }
}
