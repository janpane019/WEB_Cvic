using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using XDDDD.Model;

namespace XDDDD.Pages
{
    public class PictureUploadModel : PageModel
    {
        private readonly XDDDD.Model.GalleryDbContext _context;

        public PictureUploadModel(XDDDD.Model.GalleryDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<SelectListItem> AlbumsList { get; set; }

        public IActionResult OnGet()
        {
            AlbumsList = _context.Albums.AsEnumerable().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            return Page();
        }

        [BindProperty]
        public Picture Picture { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pictures.Add(Picture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
