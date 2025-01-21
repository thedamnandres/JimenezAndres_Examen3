using System.Collections.ObjectModel;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JimenezAndres_Examen3.Services;
using Movie = JimenezAndres_Examen3.Models.Movie;

namespace JimenezAndres_Examen3.ViewModels;

public partial class MovieViewModel : ObservableObject
{
    private readonly MovieService _movieService;
    private readonly ListMovieViewModel _listMovieViewModel;

    [ObservableProperty]
    private string movieName;

    [ObservableProperty]
    private string mensaje;

    public ObservableCollection<Movie> Movies { get; } = new();

    public MovieViewModel()
    {
        _movieService = new MovieService();
        _listMovieViewModel = new ListMovieViewModel();
    }
    
    [RelayCommand]
    public async Task SearchMovieAsync()
    {
        try
        {
            using var httpClient = new HttpClient();
            string url = $"https://www.freetestapi.com/api/v1/movies?search={MovieName}";
            var response = await httpClient.GetFromJsonAsync<List<ApiResponse>>(url);

            if (response != null && response.Count > 0)
            {
                var movie = response[0];
                var actor = movie.Actors != null && movie.Actors.Count > 0 ? movie.Actors[0] : "Desconocido";
                var genre = movie.Genre != null && movie.Genre.Count > 0 ? string.Join(", ", movie.Genre) : "Desconocido";

                Mensaje = $"Titulo: {movie.Title}\nGenero: {genre}\nMain Actor: {actor}\nAwards: {movie.Awards}\nWebsite: {movie.Website}\nMy Name: Andres Jimenez";

                var newMovie = new Movie
                {
                    MovieName = movie.Title,
                    Gender = genre,
                    Actor = actor,
                    Awards = movie.Awards,
                    Website = movie.Website
                };
                
                _movieService.AddMovie(newMovie);
            }
            else
            {
                Mensaje = "No se encontró la película.";
            }
        }
        catch (Exception e)
        {
            Mensaje = $"Error: {e.Message}";
        }
    }
    
    [RelayCommand]
    public void Limpiar()
    {
        MovieName = string.Empty;
        Mensaje = string.Empty;
    }
    
    public class ApiResponse
    {
        public string Title { get; set; }
        public List<string>  Genre { get; set; }
        public List<string> Actors { get; set; }
        public string Awards { get; set; }
        public string Website { get; set; }
    }
    
}