using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.UI.Configuration
{
    [Authorize]
    public abstract class MainController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly INotifierService _notifierService;

        public MainController(IMapper mapper, INotifierService notifierService)
        {
            _mapper = mapper;
            this._notifierService = notifierService;
        }

        protected bool ValidOperation()
        {
            return _notifierService.HasError() ? false:true;
        }
    }
}
