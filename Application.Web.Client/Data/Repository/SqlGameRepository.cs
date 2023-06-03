using Application.Database;
using Application.Database.Models;
using Application.WebClient.Data.Repository;

namespace Application.Web.Client.Data.Repository
{
    public class SqlGameRepository : IRepository
    {
        private readonly TourAgencyContext _db;
        public SqlGameRepository(TourAgencyContext db)
        {
            _db = db;
        }
        public List<Tour> GetAllGames()
        {
            var games = _db.Tours.ToList();
            return games;
        }

        public bool CreateNewGame(Tour newGame)
        {
            if (newGame is null)
                return false;
            _db.Add(newGame);
            _db.SaveChanges();
            return true;
        }
        public bool CreateNewStudio(TourOperator Developer)
        {
            if (Developer is null)
                return false;
            _db.Add(Developer);
            _db.SaveChanges();
            return true;
        }

        public bool CreateNewGenre(Transport genre)
        {
            if(genre is null)
                return false;
            _db.Add(genre);
            _db.SaveChanges();
            return true;
        }

        public Tour GetGameById(int id)
        {
            var game = _db.Tours.FirstOrDefault(x => x.TourId == id);
            return game;
        }

        public List<Transport> GetAllGenres()
        {
            var genres = _db.Transports.ToList();
            return genres;
        }

        public Transport GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditGenre(Transport editedGenre)
        {
            if(editedGenre is null)
                return false;
            _db.Transports.Update(editedGenre);
            _db.SaveChanges();
            return true;
        }

        public List<TourOperator> GetAllDevelopers()
        {
            var developers = _db.TourOperators.ToList();
            return developers;
        }
        //public List<Tour> RemoveGame()
        //{
        //    var game = _db.Tours.ToList();
        //    _db.Remove(game);
        //    _db.SaveChanges();
        //    return game;
        //}
        public List<Tour> RemoveGame(Tour game)
        {
           // var games = _db.Tours.ToList();
            _db.Remove(game);
            _db.SaveChanges();
            var games = _db.Tours.ToList();
            return games;
        }
        public List<Tour> UpdateGame(Tour game)
        {
            _db.Update(game);
            _db.SaveChanges();
            var games = _db.Tours.ToList();
            return games;
        }
    }
}
