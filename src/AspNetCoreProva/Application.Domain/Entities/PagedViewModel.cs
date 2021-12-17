using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class PagedViewModel<T> : IPagedViewModel where T : class
    {
        public string ReferenceAction { get; set; }
        public IEnumerable<T> List { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public int TotalResult { get; set; }
        public double TotalPages => Math.Ceiling((double)TotalResult / PageSize);

        public bool PreviousPage => PageIndex > 1;
        public bool NextPage => PageIndex < TotalPages;
    }

    public interface IPagedViewModel
    {
        public string ReferenceAction { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public int TotalResult { get; set; }
        public double TotalPages { get; }
        public bool PreviousPage { get; }
        public bool NextPage { get; }
    }
}
