using Application.Database.Models;

namespace Application.WebClient.Data.Repository
{
    public interface IRepository
    {
        List<Tour> GetAllGames();
        List<Transport> GetAllGenres();
        bool CreateNewGame(Tour newGame);
        bool CreateNewGenre(Transport genre);
        bool CreateNewStudio(TourOperator Developer);
        Tour GetGameById(int id);
        Transport GetGenreById(int id);
        List<Tour> RemoveGame(Tour game);
        List<Tour> UpdateGame(Tour game);
        bool EditGenre(Transport editedGenre);
        List<TourOperator> GetAllDevelopers();
    }
}
