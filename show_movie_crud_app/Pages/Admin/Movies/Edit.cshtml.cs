using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using show_movie_crud_app.Models;
using show_movie_crud_app.Services;

namespace show_movie_crud_app.Pages.Admin.Movies
{
    [Authorize]
    public class EditModel : PageModel
    {
        /*
            First we need the applicationdbcontext that allows us to access the database. 
            Also we need an object of type Iwebhostenviornment that allows us to update the image on the server
        */

        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        //Bind MovieDto Model to The Edit Razor Page
        [BindProperty]
        public MovieDto MovieDto { get; set; } = new MovieDto();

        //constructor that request the applicationdbcontext & iwebhostenvironment services as variables
        public EditModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }


        //Access UrlParameter id
        public void OnGet(Guid? id)
        {
            //Access Table in Database and Find a specific record by id
            var movie = context.Movies.Find(id);
            if (movie == null)
            {
                Response.Redirect("/Index");
            }

            //we will read the product details from the database and initilaize MovieDto
            //This will also initialize the Form Fields that link to this Model
            MovieDto.Title = movie.Title;
            MovieDto.Genre = movie.Genre;
            MovieDto.Rating = (int) movie.Rating;
            MovieDto.Description = movie.Description;
        }

        //Access UrlParameter id
        public void OnPost(Guid? id)
        {
            if(id == null)
            {
                Response.Redirect("/Index");
            }

            //Check if Input is Legit
            if(!ModelState.IsValid)
            {
                //If Fields are not conforming to Validation in MovieDto, then the post is prevented
                return;
            }

            //Find record in database by Id
            var movie = context.Movies.Find(id);

            //Update record with user input from form
            movie.Title = MovieDto.Title;
            movie.Genre = MovieDto.Genre;
            movie.Rating = MovieDto.Rating;
            movie.Cover = MovieDto.Cover?.FileName;
            movie.Description = MovieDto.Description;

            //save changes
            context.SaveChanges();

            //redirect after post
            Response.Redirect("/Index");
        }
    }
}