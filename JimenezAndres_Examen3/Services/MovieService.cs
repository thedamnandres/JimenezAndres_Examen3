using SQLite;
using Movie = JimenezAndres_Examen3.Models.Movie;
using Path = System.IO.Path;

namespace JimenezAndres_Examen3.Services;

public class MovieService 
{

    private readonly SQLiteConnection _database;

    public MovieService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "jimenezandres_movies.db");
        _database = new SQLiteConnection(dbPath);
        _database.CreateTable<Movie>();
    }

    public void AddMovie(Movie movie)
    {
        _database.Insert(movie);
    }

    public List<Movie> GetMovies()
    {
        return _database.Table<Movie>().ToList();
    }
}