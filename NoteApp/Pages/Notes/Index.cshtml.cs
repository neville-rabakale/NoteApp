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
    public class IndexModel : PageModel
    {
        private readonly NoteApp.Model.ApplicationDbContext _context;

        public IndexModel(NoteApp.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NoteModel> NoteModel { get;set; }

        public async Task OnGetAsync()
        {
            NoteModel = await _context.NoteModel.ToListAsync();
        }
    }
}
