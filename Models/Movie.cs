namespace MoviesProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

//EF Core is an object-relational mapping (ORM) framework that simplifies the data access code. Model classes don’t have any dependency on EF Core. They just define the properties of the data that will be stored in the database.
// In this we will write the model classes first and EF Core will create the database. This is called Code First Approach.