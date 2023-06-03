using Application.Persistence;
using Application.Persistence.Models;
using GameIndustry_v2.Pages.GenrePages;

namespace GameIndustry_v2.Data.Repository
{
    public class SqlGameRepository : IRepository
    {
        private readonly ApplicationDbContext _db;
        public SqlGameRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<GameModel> GetAllGames()
        {
            var games = _db.GameModels.ToList();
            return games;
        }

        public bool CreateNewGame(GameModel newGame)
        {
            if (newGame is null)
                return false;
            _db.Add(newGame);
            _db.SaveChanges();
            return true;
        }
        public bool CreateNewStudio(GameDeveloper Developer)
        {
            if (Developer is null)
                return false;
            _db.Add(Developer);
            _db.SaveChanges();
            return true;
        }

        public bool CreateNewGenre(Genre genre)
        {
            if(genre is null)
                return false;
            _db.Add(genre);
            _db.SaveChanges();
            return true;
        }

        public GameModel GetGameById(int id)
        {
            var game = _db.GameModels.FirstOrDefault(x => x.Id == id);
            return game;
        }

        public List<Genre> GetAllGenres()
        {
            var genres = _db.Genres.ToList();
            return genres;
        }

        public Genre GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditGenre(Genre editedGenre)
        {
            if(editedGenre is null)
                return false;
            _db.Genres.Update(editedGenre);
            _db.SaveChanges();
            return true;
        }

        public List<GameDeveloper> GetAllDevelopers()
        {
            var developers = _db.GameDevelopers.ToList();
            return developers;
        }
        //public List<GameModel> RemoveGame()
        //{
        //    var game = _db.GameModels.ToList();
        //    _db.Remove(game);
        //    _db.SaveChanges();
        //    return game;
        //}
        public List<GameModel> RemoveGame(GameModel game)
        {
           // var games = _db.GameModels.ToList();
            _db.Remove(game);
            _db.SaveChanges();
            var games = _db.GameModels.ToList();
            return games;
        }
        public List<GameModel> UpdateGame(GameModel game)
        {
            _db.Update(game);
            _db.SaveChanges();
            var games = _db.GameModels.ToList();
            return games;
        }
    }
}
