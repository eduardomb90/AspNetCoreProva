using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialMovieDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Director = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Gross = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("d0eee2ec-375b-45f9-b27f-d9ba62ea3039"), "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.).", "Action" },
                    { new Guid("18c09a9f-75be-471a-87ea-e17c53ab39ae"), "An adventure story is about a protagonist who journeys to epic or distant places to accomplish something. It can have many other genre elements included within it, because it is a very open genre.", "Adventure" },
                    { new Guid("87cd7169-aa4f-45b0-b53c-93e37c9e03dd"), "Technically speaking, animation is more of a medium than a film genre in and of itself; as a result, animated movies can run the gamut of traditional genres with the only common factor being that they don’t rely predominantly on live action footage.", "Animation" },
                    { new Guid("282bcfb8-0692-4506-ba79-77683854b48f"), "Comedy is a story that tells about a series of funny or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basis.", "Comedy" },
                    { new Guid("66ac5ce8-9f4d-4edc-a9e6-813c7433c360"), "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. The stereotypical plot line follows the boy-gets-girl, boy-loses-girl, boy gets girl back again sequence. ", "Romantic Comedy" },
                    { new Guid("b4c2609d-53d8-4297-9d61-6edda046cb0e"), "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. ", "Crime" },
                    { new Guid("468724d7-1c44-4049-b2db-dab042e82b97"), "Within film, television and radio (but not theatre), drama is a genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone,", "Drama" },
                    { new Guid("2a64d5d4-1c41-4094-9cce-32bdd04e1a3c"), "Science fiction is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. ", "Sci-Fi" },
                    { new Guid("05020464-be32-4972-92db-1817f91aea38"), "Romance novels are emotion-driven stories that are primarily focused on the relationship between the main characters of the story.", "Romance" },
                    { new Guid("690c5d6d-1893-4687-80b6-0f43d5386643"), "A fantasy story is about magic or supernatural forces, rather than technology, though it often is made to include elements of other genres, such as science fiction elements, for instance computers or DNA, if it happens to take place in a modern or future era. ", "Fantasy" },
                    { new Guid("cdc15b3f-9407-4e5b-8644-63ee9eeb8a02"), "The coverage of sports as a television program, on radio and other broadcasting media. It usually involves one or more sports commentators describing the events as they happen, which is called colour commentary.", "Sport" },
                    { new Guid("70569ac5-abce-4c31-845f-6b82adb231d3"), "tories in the Western genre are set in the American West, between the time of the Civil war and the early nineteenth century.", "Western" },
                    { new Guid("516b38a7-5451-48b2-85b7-9891aaed7668"), "A Thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. ", "Thriller" },
                    { new Guid("ad5d2dbf-e7ca-4a97-b152-c13c016e162c"), "The family saga is a genre of literature which chronicles the lives and doings of a family or a number of related or interconnected families over a period of time. ", "Family" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "GenreId", "Gross", "ImageUrl", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("da233b1d-6b3f-4dd3-af56-7361c98aa202"), "Christopher Nolan", new Guid("d0eee2ec-375b-45f9-b27f-d9ba62ea3039"), 533316061m, null, 9.0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("ecba6154-0573-44e4-920f-fedb69ad2b30"), "Quentin Tarantino", new Guid("516b38a7-5451-48b2-85b7-9891aaed7668"), 107930000m, null, 8.9000000000000004, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("2bbde433-cf8c-4885-ac1d-22f967b4af52"), "Howard Hawks", new Guid("70569ac5-abce-4c31-845f-6b82adb231d3"), 5750000m, null, 8.0999999999999996, new DateTime(1959, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rio Bravo" },
                    { new Guid("0b2885eb-8ba4-4be1-b601-f7f2b9498cf9"), "Stanley Kubrick", new Guid("2a64d5d4-1c41-4094-9cce-32bdd04e1a3c"), 56715371m, null, 8.3000000000000007, new DateTime(1968, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2001: A Space Odyssey" },
                    { new Guid("b8c81cd8-4242-410e-9768-aeefe01307f6"), "The Wachowski Brothers", new Guid("2a64d5d4-1c41-4094-9cce-32bdd04e1a3c"), 171383253m, null, 8.6999999999999993, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("0a1a5650-ce87-41b6-8af2-73e66fa79268"), "Steven Spielberg", new Guid("468724d7-1c44-4049-b2db-dab042e82b97"), 96067179m, null, 8.9000000000000004, new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindlers List" },
                    { new Guid("1ef18b4f-5ce4-41b0-a6c9-dc815effc846"), "Francis Ford Coppola", new Guid("468724d7-1c44-4049-b2db-dab042e82b97"), 134821952m, null, 9.1999999999999993, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("03c2b261-4954-4f0b-8d2d-8e96250912d6"), "Robert Zemeckis", new Guid("ad5d2dbf-e7ca-4a97-b152-c13c016e162c"), 210609762m, null, 8.5, new DateTime(1989, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back to the Future" },
                    { new Guid("df399d10-27ff-490a-ac61-8a4f0ced6c95"), "Frank Darabont", new Guid("468724d7-1c44-4049-b2db-dab042e82b97"), 28341469m, null, 9.3000000000000007, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("3d61f64a-638e-4093-bb51-ec86c57a3ed8"), " Terry Gilliam & Terry Jones", new Guid("282bcfb8-0692-4506-ba79-77683854b48f"), 1229197m, null, 8.3000000000000007, new DateTime(1975, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monty Python and the Holy Grail" },
                    { new Guid("662d4afb-501d-49b3-b0c5-62fcac428dc4"), "Robert Zemeckis", new Guid("282bcfb8-0692-4506-ba79-77683854b48f"), 329691196m, null, 8.8000000000000007, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { new Guid("51e14bdc-5c79-4de1-8400-4633e5eedccf"), "Ivan Reitman", new Guid("282bcfb8-0692-4506-ba79-77683854b48f"), 112494738m, null, 6.5, new DateTime(1986, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters 2" },
                    { new Guid("21ea3b1c-98d7-4949-8c2d-fbe4ded8e7d0"), "Ivan Reitman", new Guid("282bcfb8-0692-4506-ba79-77683854b48f"), 13612564m, null, 6.5, new DateTime(1984, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters" },
                    { new Guid("a0ec20be-d18e-48ff-9db2-3b40cf734e6f"), "George Lucas", new Guid("d0eee2ec-375b-45f9-b27f-d9ba62ea3039"), 460935665m, null, 8.6999999999999993, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars" },
                    { new Guid("19a684aa-1bd4-4295-8c87-27a2979645b5"), "Peter Jackson", new Guid("d0eee2ec-375b-45f9-b27f-d9ba62ea3039"), 377019252m, null, 8.9000000000000004, new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { new Guid("59188c33-394c-4752-acf7-c9d250ba57a4"), "Rob Reiner", new Guid("66ac5ce8-9f4d-4edc-a9e6-813c7433c360"), 92823600m, null, 7.5999999999999996, new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "When Harry Met Sally" },
                    { new Guid("822c9d5a-a75c-4035-a8ef-ca70c7a185d1"), "Pete Docter & David Silverman", new Guid("ad5d2dbf-e7ca-4a97-b152-c13c016e162c"), 289907418m, null, 8.0999999999999996, new DateTime(2001, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monsters Inc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
