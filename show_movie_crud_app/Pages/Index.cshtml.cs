using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using show_movie_crud_app.Services;

namespace show_movie_crud_app.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        //use context variable to access movies from database
        private readonly ApplicationDbContext context;

        /* 
           To request the ApplicationDbContext from the service container we need to create a constructor
           of this class 
        */
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        //List to Store Data in
        public List<Models.Movie> _movieList { get; set; } = new List<Models.Movie>();
        public void OnGet()
        {
            //context.Movies.ToList() - converts records into list format
            //OrderByDescending(x => x.Id) - order movies based on Id
            _movieList = context.Movies.OrderByDescending(x => x.Id).ToList();
        }
    }
}