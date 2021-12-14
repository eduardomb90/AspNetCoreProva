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
                    ImagePath = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
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
                    { new Guid("2f60b161-3b09-4517-9243-8d773681c5a7"), "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.).", "Action" },
                    { new Guid("d2fbae0e-4bdb-4b72-ab3f-0bee95bb888d"), "An adventure story is about a protagonist who journeys to epic or distant places to accomplish something. It can have many other genre elements included within it, because it is a very open genre.", "Adventure" },
                    { new Guid("c80edcbf-7065-49f8-9678-1f62f59184ba"), "Technically speaking, animation is more of a medium than a film genre in and of itself; as a result, animated movies can run the gamut of traditional genres with the only common factor being that they don’t rely predominantly on live action footage.", "Animation" },
                    { new Guid("7f12a4de-69a8-402e-a5e4-e8592bc1412c"), "Comedy is a story that tells about a series of funny or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basis.", "Comedy" },
                    { new Guid("b3105b2e-2fc3-446f-a4a9-06a9a6d1f535"), "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. The stereotypical plot line follows the boy-gets-girl, boy-loses-girl, boy gets girl back again sequence. ", "Romantic Comedy" },
                    { new Guid("c36a85e7-2225-46b2-9602-edfb043ccd4c"), "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. ", "Crime" },
                    { new Guid("0116dfc4-89f5-4cbc-9a4e-730b99251c99"), "Within film, television and radio (but not theatre), drama is a genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone,", "Drama" },
                    { new Guid("4c789ee2-1bcb-44e3-a00b-5b8380c749da"), "Science fiction is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. ", "Sci-Fi" },
                    { new Guid("0d4084fe-2721-49af-b175-9f3b48136680"), "Romance novels are emotion-driven stories that are primarily focused on the relationship between the main characters of the story.", "Romance" },
                    { new Guid("5bd4675c-ef42-4773-bc23-387e14217cf5"), "A fantasy story is about magic or supernatural forces, rather than technology, though it often is made to include elements of other genres, such as science fiction elements, for instance computers or DNA, if it happens to take place in a modern or future era. ", "Fantasy" },
                    { new Guid("f5a18b25-31b6-4548-80d3-0e16c3ffce09"), "The coverage of sports as a television program, on radio and other broadcasting media. It usually involves one or more sports commentators describing the events as they happen, which is called colour commentary.", "Sport" },
                    { new Guid("494ed9cc-5bf8-4661-8b12-d3a1b3448ad8"), "tories in the Western genre are set in the American West, between the time of the Civil war and the early nineteenth century.", "Western" },
                    { new Guid("620daa39-ad15-48ec-9ef1-935e6b005664"), "A Thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. ", "Thriller" },
                    { new Guid("3ab6092e-ac32-42ac-96b1-962e8b2880c6"), "The family saga is a genre of literature which chronicles the lives and doings of a family or a number of related or interconnected families over a period of time. ", "Family" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "GenreId", "Gross", "ImagePath", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("eb531e9e-ada0-4442-8e77-ec3ec38f0ca7"), "Christopher Nolan", new Guid("2f60b161-3b09-4517-9243-8d773681c5a7"), 533316061m, null, 9.0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("5f5343e9-9f25-4dfd-80e0-0b92781e3483"), "Quentin Tarantino", new Guid("620daa39-ad15-48ec-9ef1-935e6b005664"), 107930000m, null, 8.9000000000000004, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("8cf409d5-6e0e-4513-a661-362106f4964a"), "Howard Hawks", new Guid("494ed9cc-5bf8-4661-8b12-d3a1b3448ad8"), 5750000m, null, 8.0999999999999996, new DateTime(1959, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rio Bravo" },
                    { new Guid("f73b0370-d698-47ad-a74c-11677fa3264a"), "Stanley Kubrick", new Guid("4c789ee2-1bcb-44e3-a00b-5b8380c749da"), 56715371m, null, 8.3000000000000007, new DateTime(1968, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "2001: A Space Odyssey" },
                    { new Guid("d67c562a-3f3d-4aea-85b1-40b21240213c"), "The Wachowski Brothers", new Guid("4c789ee2-1bcb-44e3-a00b-5b8380c749da"), 171383253m, null, 8.6999999999999993, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("46836761-ad64-4f40-b75c-c9d76f73111d"), "Steven Spielberg", new Guid("0116dfc4-89f5-4cbc-9a4e-730b99251c99"), 96067179m, null, 8.9000000000000004, new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindlers List" },
                    { new Guid("11117691-4a26-45a9-b23b-6ad45d6a3ff0"), "Francis Ford Coppola", new Guid("0116dfc4-89f5-4cbc-9a4e-730b99251c99"), 134821952m, null, 9.1999999999999993, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("839650de-b327-493d-9618-6c0be9cbb19c"), "Robert Zemeckis", new Guid("3ab6092e-ac32-42ac-96b1-962e8b2880c6"), 210609762m, null, 8.5, new DateTime(1989, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back to the Future" },
                    { new Guid("5424d100-6627-4b63-b542-a9c667ee52e4"), "Frank Darabont", new Guid("0116dfc4-89f5-4cbc-9a4e-730b99251c99"), 28341469m, null, 9.3000000000000007, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("82e1326b-eec1-425d-a348-297da8d37e1d"), " Terry Gilliam & Terry Jones", new Guid("7f12a4de-69a8-402e-a5e4-e8592bc1412c"), 1229197m, null, 8.3000000000000007, new DateTime(1975, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monty Python and the Holy Grail" },
                    { new Guid("af640b80-33da-41b4-b2fb-d82dcbd11905"), "Robert Zemeckis", new Guid("7f12a4de-69a8-402e-a5e4-e8592bc1412c"), 329691196m, null, 8.8000000000000007, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { new Guid("76c04223-ba1f-455f-95f5-09d20595285b"), "Ivan Reitman", new Guid("7f12a4de-69a8-402e-a5e4-e8592bc1412c"), 112494738m, null, 6.5, new DateTime(1986, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters 2" },
                    { new Guid("f9b3891b-a554-4001-b483-e4ff789ae83e"), "Ivan Reitman", new Guid("7f12a4de-69a8-402e-a5e4-e8592bc1412c"), 13612564m, null, 6.5, new DateTime(1984, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters" },
                    { new Guid("beddb2ef-57af-4f55-a8bb-99f655403bf6"), "George Lucas", new Guid("2f60b161-3b09-4517-9243-8d773681c5a7"), 460935665m, null, 8.6999999999999993, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars" },
                    { new Guid("700140c3-9f23-4e68-a8b1-b3fb3598ea16"), "Peter Jackson", new Guid("2f60b161-3b09-4517-9243-8d773681c5a7"), 377019252m, null, 8.9000000000000004, new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { new Guid("e4ab1450-02ed-448e-b946-5b2b5bb971de"), "Rob Reiner", new Guid("b3105b2e-2fc3-446f-a4a9-06a9a6d1f535"), 92823600m, null, 7.5999999999999996, new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "When Harry Met Sally" },
                    { new Guid("bc307e34-5b3f-4160-b218-23453b2d1b11"), "Pete Docter & David Silverman", new Guid("3ab6092e-ac32-42ac-96b1-962e8b2880c6"), 289907418m, null, 8.0999999999999996, new DateTime(2001, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monsters Inc" }
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
