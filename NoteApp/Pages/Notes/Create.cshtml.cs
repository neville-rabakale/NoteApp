using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteApp.Model;

namespace NoteApp.Pages.Notes
{
    public class CreateModel : PageModel
    {
        //Private applicationDbContext object named _db 
        private readonly NoteApp.Model.ApplicationDbContext _db;


        //Create models own db object
        public CreateModel(NoteApp.Model.ApplicationDbContext db)
        {
            _db = db;
        }
        
        //OnGet return the page :)
        public IActionResult OnGet()
        {
            return Page();
        }

        //NoteModel Object 
        [BindProperty]
        public NoteModel Notes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Add changes to NoteModel and Save
            _db.NoteModel.Add(Notes);
            await _db.SaveChangesAsync();
            //Return to Index Page
            return RedirectToPage("./Index");


        }
    }
}
