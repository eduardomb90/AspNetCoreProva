using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.UI.Configuration;
using WebMvc.UI.Models;

namespace WebMvc.UI.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, INotifierService notifierService) 
        : base(mapper, notifierService)
        {
            _logger = logger;
        }

        [AllowAnonymous]

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
