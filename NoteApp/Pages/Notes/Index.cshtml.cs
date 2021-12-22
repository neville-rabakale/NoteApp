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
    //Inhertit Page model as index model
    public class IndexModel : PageModel
    {
        //invoke private db object of type ApplicationDbContext
        private readonly NoteApp.Model.ApplicationDbContext _db;
        //Function that calls index model with db as input
        public IndexModel(NoteApp.Model.ApplicationDbContext db)
        {
            //private db as public db
            _db = db;
        }

        //NoteModel object
        public IList<NoteModel> NoteModel { get;set; }

        //get for Index
        public async Task OnGetAsync()
        {
            //call index note model from db
            NoteModel = await _db.NoteModel.ToListAsync();
        }
    }
}
