using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDDDD.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace XDDDD.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GalleryDbContext dbContext;

        public IEnumerable<Album> Albums { get; set; }
        [BindProperty]
        [Required]
        public string NewAlbumName { get; set; }

        public IndexModel(ILogger<IndexModel> logger, GalleryDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Albums = dbContext.Albums.Take(10)
                .Include(a => a.Pictures).AsEnumerable();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var data = NewAlbumName;
            dbContext.Albums.Add(new Album { Name = NewAlbumName, CreatedAt = DateTime.Now });
            dbContext.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
