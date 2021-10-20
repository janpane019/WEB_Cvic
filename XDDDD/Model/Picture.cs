using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XDDDD.Model
{
    public class Picture
    {
        public int Id { get; set; }
        [Required]
        public string PictureName { get; set; }
        [Required]
        public Album LocatedAlbum { get; set; }
        [ForeignKey("LocatedAlbum")]
        public int LocatedAlbumId { get; set; }
        public int? Order { get; set; }
    }
}
