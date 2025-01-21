using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using JimenezAndres_Examen3.Models;
using JimenezAndres_Examen3.Services;

namespace JimenezAndres_Examen3.ViewModels;

public partial class ListMovieViewModel : ObservableObject
{
    private readonly MovieService _movieService;

    [ObservableProperty]
    private ObservableCollection<string> movies;

    public ListMovieViewModel()
    {
        _movieService = new MovieService();
        LoadMovies();
    }

    private async void LoadMovies()
    {
        var listaMovies = _movieService.GetMovies();
        Movies = new ObservableCollection<string>(
            listaMovies.Select(m =>
                $"Titulo: {m.MovieName}\nGenero: {m.Gender}\nMain Actor: {m.Actor}\nAwards: {m.Awards}\nWebsite: {m.Website}\nAJimenez: Andres Jimenez"
            )
        );
    }
    
}