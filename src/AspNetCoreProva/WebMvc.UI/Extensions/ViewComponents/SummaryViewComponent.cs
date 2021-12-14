using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.UI.Extensions.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotifierService _notifierService;

        public SummaryViewComponent(INotifierService notifierService)
        {
            _notifierService = notifierService;
        }

        public IViewComponentResult Invoke()
        {
            var notifications = _notifierService.GetErrors().Select(x => x.ErrorMessage).ToList();

            notifications.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x + "<br />"));

            return View(notifications);
        }

        //Adicionar à view
    }
}
