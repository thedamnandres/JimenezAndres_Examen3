using SQLite;
using Movie = JimenezAndres_Examen3.Models.Movie;
using Path = System.IO.Path;

namespace JimenezAndres_Examen3.Services;

public class MovieService 
{

    private readonly SQLiteAsyncConnection _database;

    public MovieService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "jimenezandres_movies.db");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Movie>().Wait();
    }

    public async Task AddMovieAsync(Movie movie)
    {
        await _database.InsertAsync(movie);
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        return await _database.Table<Movie>().ToListAsync();
    }
}