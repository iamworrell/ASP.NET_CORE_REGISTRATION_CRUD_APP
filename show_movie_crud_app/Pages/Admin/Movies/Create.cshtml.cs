using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using show_movie_crud_app.Models;
using show_movie_crud_app.Services;

namespace show_movie_crud_app.Pages.Admin.Movies
{
    [Authorize]
    public class CreateModel : PageModel
    {
        //Bind MovieDto to Razor Page
        [BindProperty]
        public MovieDto MovieDto { get; set; } = new MovieDto();
        /*
           onpost method that allows us to save the movie cover on the server and add
           new movie to the database. To do this we need applicationdbcontext and object 
           of type IWebHostEnvironment that allows us to save the image on the server.ron

           environment is a variable of IWebHostEnvironment type
           context is a variable of ApplicationDbContext type
       */

        //save variables into fields - environment used to save image on server, context save data in database
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            //Check State of Model
            if (!ModelState.IsValid)
            {
                //since the MovieDto is binded to the Create.cshtml page
                //on Submit/Post if the input fields do not conform to the restrictions set in the MovieDto
                //the ModelState is not Valid, we return and prevent the program from running any further
                return;
            }

            //SAVE THE IMAGE FILE ON SERVER

            //SAVE MOVIE IN DATABASE
            Movie movie = new Movie()
            {
                //All this Information is coming from the form
                Id = new Guid(),
                Title = MovieDto.Title,
                Genre = MovieDto.Genre,
                Rating = MovieDto.Rating,
                Cover = MovieDto.Cover?.FileName,
                Description = MovieDto.Description,
            };

            //Add and Save Info
            context.Movies.Add(movie);
            context.SaveChanges();

            //clear form after post
            MovieDto.Title = "";
            MovieDto.Genre = "";
            MovieDto.Description = "";

            //Clear Model State
            ModelState.Clear();

            //Redirect
            Response.Redirect("/Index");
        }
    }
}