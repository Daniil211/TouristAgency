using Application.Persistence.Models;

namespace GameIndustry_v2.Data.Repository
{
    public interface IRepository
    {
        List<GameModel> GetAllGames();
        bool CreateNewGame(GameModel newGame);
        bool CreateNewGenre(Genre genre);
        bool CreateNewStudio(GameDeveloper Developer);
        GameModel GetGameById(int id);
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        List<GameModel> RemoveGame(GameModel game);
        List<GameModel> UpdateGame(GameModel game);
        bool EditGenre(Genre editedGenre);
        List<GameDeveloper> GetAllDevelopers();
    }
}
