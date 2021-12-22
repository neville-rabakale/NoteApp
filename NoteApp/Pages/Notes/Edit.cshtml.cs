using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteApp.Model;

namespace NoteApp.Pages.Notes
{
    public class EditModel : PageModel
    {
        //Private applicationDbContext object named _db 
        private readonly NoteApp.Model.ApplicationDbContext _db;


        //Create models own db object
        public EditModel(NoteApp.Model.ApplicationDbContext db)
        {
            _db = db;
        }

        //NoteModel Object 
        [BindProperty]
        public NoteModel Notes { get; set; }


        //OnGetAsync return the page depending on the id :)
        public async Task <IActionResult> OnGetAsync(int? id)
        {
            //if id is null, page does not exist (somethinng went wrong)
            if(id == null)
            {
                return NotFound();
            }

            //get data from NoteModel Notes db
            Notes = await _db.NoteModel.FirstOrDefaultAsync(m => m.Id == id);

            if(Notes == null)
            {
                return NotFound();
            }

            return Page();
        }

 
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Updating Notes and Changing the state of db object to modified
            _db.Attach(Notes).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            //if saving to databse fails return DbException
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(Notes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //Return to Index Page
            return RedirectToPage("./Index");
        }

        //Fuction to check of an object has an id
        private bool NotesExists(int id)
        {
            return _db.NoteModel.Any(e => e.Id == id);
        }
    }
}
