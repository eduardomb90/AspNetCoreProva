using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.UI.Extensions.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedViewModel pagedViewModel)
        {
            return View(pagedViewModel);
        }
    }
}
