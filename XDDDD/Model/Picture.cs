using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XDDDD.Model
{
    public class Picture
    {
        public int Id { get; set; }
        //[Required]
        //public Uri Url { get; set; }
        public string PictureName { get; set; }
        [Required]
        public Album LocatedAlbum { get; set; }
        public int? Order { get; set; }
    }
}
