using SQLite;

namespace JimenezAndres_Examen3.Models;

public class Movie
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string MovieName { get; set; }
    public string Gender { get; set; }
    public string Actor { get; set; }
    public string Awards { get; set; }
    public string Website { get; set; }
    
}