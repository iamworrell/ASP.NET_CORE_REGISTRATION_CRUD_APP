using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using show_movie_crud_app.Services;

namespace show_movie_crud_app.Pages.Admin.Movies
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Url Parameter id
        public void OnGet(Guid? id)
        {
            //Access Database, the Table "Movies" Searches for record by id from url
            //Assign record to delete variable
            var delete = _context.Movies.Find(id);

            //Remove record
            _context.Movies.Remove(delete);

            //Save Changes
            _context.SaveChanges();

            //Redirect
            Response.Redirect("/Index");
        }
    }
}