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
    public class DetailsModel : PageModel
    {
        private readonly NoteApp.Model.ApplicationDbContext _db;

        public DetailsModel(NoteApp.Model.ApplicationDbContext db)
        {
            _db = db;
        }

        public NoteModel Notes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notes = await _db.NoteModel.FirstOrDefaultAsync(m => m.Id == id);

            if (Notes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
