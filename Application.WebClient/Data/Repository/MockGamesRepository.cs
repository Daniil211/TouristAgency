using Application.Persistence.Models;

namespace GameIndustry_v2.Data.Repository
{
    public class MockGamesRepository : IRepository
    {
        private List<GameModel> _games;
        private List<Genre> _genres;
        private List<GameDeveloper> _developers;
        private IRepository _repositoryImplementation;

        public MockGamesRepository()
        {

            _genres = new()
            {
                new()
                {
                    Id = 1,
                    Name = "RPG"
                },
                new()
                {
                    Id = 2,
                    Name = "Action"
                },
                new()
                {
                    Id = 3,
                    Name = "Horror"
                },
                new()
                {
                    Id = 4,
                    Name = "Platformer"
                },
                new()
                {
                    Id = 5,
                    Name = "Simulator"
                }
            };

            _games = new List<GameModel>()
            {
                new GameModel()
                {
                    Id = 1,
                    Name = "Farming Simulator 2019",
                    Description = "The ultimate farming simulation returns with a complete graphics overhaul and the most complete farming experience ever! Become a modern farmer and develop your farm on two huge American and European environments, filled with exciting new farming activities, crops to harvest and animals to tend to.",
                    //GamesGenres = GetRandomGenres(1),
                    //GenreId = 1,
                    ReleaseDate = new DateTime(2018, 11, 19),
                    Image = "https://cdn.verk.net/images/89/2_644443-766x1080.jpg",
                    InSale = true
                },

                new GameModel()
                {
                    Id = 2,
                    Name = "The Witcher 3",
                    //GamesGenres = GetRandomGenres(2),
                    //GenreId = 2,
                    Description = "The Witcher 3: Wild Hunt is an action role-playing game with a third-person perspective. Players control Geralt of Rivia, a monster slayer known as a Witcher. Geralt walks, runs, rolls and dodges, and (for the first time in the series) jumps, climbs and swims.",
                    ReleaseDate = new DateTime(2015, 05, 18),
                    Image = "https://cdn.verk.net/960/images/52/2_560554-2460x4000.jpg",
                    InSale = true
                },

                new GameModel()
                {
                    Id = 3,
                    Name = "Destroy All Humans!",
                    //GamesGenres = GetRandomGenres(3),
                    //GenreId = 3,
                    Description = "Destroy All Humans! is an open world action-adventure video game franchise that is designed as a parody of Cold War-era alien invasion films. Destroy All Humans! is available for the PlayStation 2 and Xbox, Destroy All Humans!",
                    ReleaseDate = new DateTime(2020, 07, 28),
                    Image = "https://images-na.ssl-images-amazon.com/images/I/81akufL4dtL._AC_SY606_.jpg",
                    InSale = true
                },
                new GameModel()
                {
                    Id = 4,
                    Name = "Farming Simulator 2022",
                    Description = "Farming Simulator 22, realistic and family-friendly as ever, returns on November 22. New features include seasonal cycles, production chains and new crops like grapes and olives. A new build mode and character creator allow for vastly improved customization.",
                    Image = "https://cdn2.unrealengine.com/egs-farmingsimulator22preorderbundle-giantssoftware-s3-2560x1440-fe0f2c2e5147.jpg",
                    ReleaseDate = new DateTime(2021, 11, 20),
                    //GamesGenres = GetRandomGenres(4),
                    //GenreId = 4,
                    InSale = false
                }
            };

            // Создаём массив разработчиков
            _developers = new()
            {
                new GameDeveloper()
                {
                    Id = 1,
                    Name = "CD Project Red",
                    StudioDescription = "Established in 2002, located in Warsaw (HQ), Kraków and Wrocław, Poland, CD PROJEKT RED was born out of raw passion for video games.",
                    Image = "https://upload.wikimedia.org/wikipedia/en/thumb/6/68/CD_Projekt_logo.svg/1200px-CD_Projekt_logo.svg.png"
                },
                new GameDeveloper()
                {
                    Id = 2,
                    Name = "GIANTS Software",
                    StudioDescription = "Farming Simulator is a farming simulation video game series developed by Giants Software and published by Focus Home Interactive. It has often been described as a farming puzzle game. ... Players are able to farm, breed livestock, grow crops and sell assets created from farming.",
                    Image = "https://giants-software.com/img/content/og_base.jpg"
                }
            };
        }


        public List<GameModel> RemoveGame(GameModel game)
        {
            throw new NotImplementedException();
        }
        public List<GameModel> UpdateGame(GameModel game)
        {
            throw new NotImplementedException();
        }

        public bool EditGenre(Genre editedGenre)
        {
            var oldGenre = _genres.FirstOrDefault(x => x.Id.Equals(editedGenre.Id));

            if (oldGenre is not null)
            {
                oldGenre = editedGenre;
                return true;
            }
            else
                return false;
        }

        public List<GameModel> GetAllGames() => _games;
        public List<Genre> GetAllGenres() => _genres;
        public List<GameDeveloper> GetAllDevelopers() => _developers;
        public Genre GetGenreById(int id) => _genres.FirstOrDefault(x => x.Id.Equals(id));
        public bool CreateNewGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public bool CreateNewStudio(GameDeveloper Developer)
        {
            throw new NotImplementedException();
        }

        public GameModel GetGameById(int id) => _games.FirstOrDefault(x => x.Id.Equals(id));

        public bool CreateNewGame(GameModel newGame)
        {
            if (newGame is null)
                return false;

            newGame.Id = _games.Max(x => x.Id) + 1;
            _games.Add(newGame);
            return true;
        }

        List<GamesGenres> GetRandomGenres(int gameId)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            var randomGenreCount = rnd.Next(1, _genres.Count);
            List<GamesGenres> genresForReturning = new List<GamesGenres>();

            for (int i = 0; i < randomGenreCount; i++)
            {
                var genreId = rnd.Next(1, _genres.Count);
                var result = _genres.FirstOrDefault(x => x.Id == genreId);
                //if (result is not null)
                //{
                //    genresForReturning.Add(
                //        new GamesGenres
                //        {
                //            GameId = gameId,
                //            GenreId = genreId
                //        });
                //}
            }
            return genresForReturning;
        }
    }
}