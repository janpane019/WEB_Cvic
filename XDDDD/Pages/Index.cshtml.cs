using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDDDD.Model;

namespace XDDDD.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GalleryDbContext dbContext;

        public IEnumerable<Album> Albums { get; set; }

        public IndexModel(ILogger<IndexModel> logger, GalleryDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Albums = dbContext.Albums.Take(10).AsEnumerable();
        }
    }
}
