using System.ComponentModel.DataAnnotations;

namespace show_movie_crud_app.Models
{
    //Model That is Used to Create Table in Databse
    public class Movie
    {
        public Guid Id { get; set; }

        //[Required(ErrorMessage = "Title Required")]
        public string? Title { get; set; }

        
        public string? Genre { get; set; }

        
        public int? Rating { get; set; }

        public string? Cover { get; set; }

        
        public string? Description { get; set; }
    }
}