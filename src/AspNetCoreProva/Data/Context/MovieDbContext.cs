﻿using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Data.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);

            var genres = new List<Genre>
            {
                new Genre ("Action", "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.)."),
                new Genre ("Adventure", "An adventure story is about a protagonist who journeys to epic or distant places to accomplish something. It can have many other genre elements included within it, because it is a very open genre."),
                new Genre ("Animation", "Technically speaking, animation is more of a medium than a film genre in and of itself; as a result, animated movies can run the gamut of traditional genres with the only common factor being that they don’t rely predominantly on live action footage."),
                new Genre ("Comedy", "Comedy is a story that tells about a series of funny or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basis."),
                new Genre ("Romantic Comedy", "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. The stereotypical plot line follows the boy-gets-girl, boy-loses-girl, boy gets girl back again sequence. " ),
                new Genre ("Crime", "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. "),
                new Genre ("Drama", "Within film, television and radio (but not theatre), drama is a genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone,"),
                new Genre ("Sci-Fi", "Science fiction is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. "),
                new Genre ("Romance", "Romance novels are emotion-driven stories that are primarily focused on the relationship between the main characters of the story."),
                new Genre ("Fantasy", "A fantasy story is about magic or supernatural forces, rather than technology, though it often is made to include elements of other genres, such as science fiction elements, for instance computers or DNA, if it happens to take place in a modern or future era. "),
                new Genre ("Sport", "The coverage of sports as a television program, on radio and other broadcasting media. It usually involves one or more sports commentators describing the events as they happen, which is called colour commentary."),
                new Genre ("Western", "tories in the Western genre are set in the American West, between the time of the Civil war and the early nineteenth century."),
                new Genre ("Thriller", "A Thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. "),
                new Genre ("Family", "The family saga is a genre of literature which chronicles the lives and doings of a family or a number of related or interconnected families over a period of time. ")

            };

            modelBuilder.Entity<Genre>().HasData(genres);

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Title = "When Harry Met Sally", ReleaseDate = DateTime.Parse("1/11/1989", new CultureInfo("en-US")), Director = "Rob Reiner", GenreId = genres.Single(g => g.Name == "Romantic Comedy").Id, Rating = 7.6, Gross = 92823600 },
            new Movie { Title = "Ghostbusters", ReleaseDate = DateTime.Parse("3/13/1984", new CultureInfo("en-US")), Director = "Ivan Reitman", GenreId = genres.Single(g => g.Name == "Comedy").Id, Rating = 6.5, Gross = 13612564 },
            new Movie { Title = "Ghostbusters 2", ReleaseDate = DateTime.Parse("2/23/1986", new CultureInfo("en-US")), Director = "Ivan Reitman", GenreId = genres.Single(g => g.Name == "Comedy").Id, Rating = 6.5, Gross = 112494738 },
            new Movie { Title = "Rio Bravo", ReleaseDate = DateTime.Parse("4/15/1959", new CultureInfo("en-US")), Director = "Howard Hawks", GenreId = genres.Single(g => g.Name == "Western").Id, Rating = 8.1, Gross = 5750000 },
            new Movie { Title = "The Shawshank Redemption", ReleaseDate = DateTime.Parse("10/14/1994", new CultureInfo("en-US")), Director = "Frank Darabont", GenreId = genres.Single(g => g.Name == "Drama").Id, Gross = 28341469, Rating = 9.3 },
            new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseDate = DateTime.Parse("3/24/1972", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Drama").Id, Gross = 134821952, Rating = 9.2 },
            new Movie { Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseDate = DateTime.Parse("10/14/1994", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Thriller").Id, Gross = 107930000, Rating = 8.9 },
            new Movie { Title = "Schindlers List", Director = "Steven Spielberg", ReleaseDate = DateTime.Parse("2/4/1994", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Drama").Id, Gross = 96067179, Rating = 8.9 },
            new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseDate = DateTime.Parse("7/18/2008", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Action").Id, Gross = 533316061, Rating = 9.0 },
            new Movie { Title = "The Lord of the Rings: The Return of the King", Director = "Peter Jackson", ReleaseDate = DateTime.Parse("12/17/2003", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Action").Id, Gross = 377019252, Rating = 8.9 },
            new Movie { Title = "Star Wars", Director = "George Lucas", ReleaseDate = DateTime.Parse("5/25/1977", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Action").Id, Gross = 460935665, Rating = 8.7 },
            new Movie { Title = "The Matrix", Director = "The Wachowski Brothers", ReleaseDate = DateTime.Parse("3/31/1999", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Sci-Fi").Id, Gross = 171383253, Rating = 8.7 },
            new Movie { Title = "Forrest Gump", Director = "Robert Zemeckis", ReleaseDate = DateTime.Parse("7/6/1994", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Comedy").Id, Gross = 329691196, Rating = 8.8 },
            new Movie { Title = "Monty Python and the Holy Grail", Director = " Terry Gilliam & Terry Jones", ReleaseDate = DateTime.Parse("5/23/1975", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Comedy").Id, Gross = 1229197, Rating = 8.3 },
            new Movie { Title = "2001: A Space Odyssey", Director = "Stanley Kubrick", ReleaseDate = DateTime.Parse("4/29/1968", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Sci-Fi").Id, Gross = 56715371, Rating = 8.3 },
            new Movie { Title = "Back to the Future", Director = "Robert Zemeckis", ReleaseDate = DateTime.Parse("1/22/1989", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Family").Id, Gross = 210609762, Rating = 8.5 },
            new Movie { Title = "Monsters Inc", Director = "Pete Docter & David Silverman", ReleaseDate = DateTime.Parse("11/2/2001", new CultureInfo("en-US")), GenreId = genres.Single(g => g.Name == "Family").Id, Gross = 289907418, Rating = 8.1 }
            );
        }
    }
}
