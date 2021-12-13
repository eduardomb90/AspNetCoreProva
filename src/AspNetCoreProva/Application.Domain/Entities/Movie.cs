using System;

namespace Application.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public decimal Gross { get; set; }
        public double Rating { get; set; }

        //Foreign Key
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        //Image File
        public string ImageUrl { get; set; }

        public Movie()
        {
        }

        public Movie(string title, DateTime releaseDate, string director, decimal gross, double rating, Guid genreId)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Director = director;
            Gross = gross;
            Rating = rating;
            GenreId = genreId;
        }
    }
}
