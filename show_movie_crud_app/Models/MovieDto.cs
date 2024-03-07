using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace show_movie_crud_app.Models
{
    public class MovieDto
    {
        //[BindProperty]
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is Required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Please Give a Rating")]
        public int Rating { get; set; }

        public IFormFile? Cover { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
    }
}