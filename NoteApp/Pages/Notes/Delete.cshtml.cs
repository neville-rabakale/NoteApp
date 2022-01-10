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
    public class DeleteModel : PageModel
    {
        //Init private application db db
        private readonly NoteApp.Model.ApplicationDbContext _db;

        //public db db for delete
        public DeleteModel(NoteApp.Model.ApplicationDbContext db)
        {
            _db = db;
        }

        //init NoteModel
        [BindProperty]
        public NoteModel NoteModel { get; set; }

        //Get item using id -- returns page or error(Not Found)
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteModel = await _db.NoteModel.FirstOrDefaultAsync(m => m.Id == id);

            if (NoteModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //find item to be removed using id
            NoteModel = await _db.NoteModel.FindAsync(id);
            //remove item
            if (NoteModel != null)
            {
                _db.NoteModel.Remove(NoteModel);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
