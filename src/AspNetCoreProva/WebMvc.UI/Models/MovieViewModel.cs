using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.UI.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public decimal Gross { get; set; }
        public double Rating { get; set; }
              
        public Guid GenreId { get; set; }
        public virtual GenreViewModel Genre { get; set; }

        public string ImageUrl { get; set; }


        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
