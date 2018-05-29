using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Artist Name")]
        public string Name { get; set; }
        [Display(Name = "Artist Image Url")]
        public string ArtistImageURL { get; set; }
        public ICollection<Album> Albums { get; set; }



        //public void DoStuff(bool IsOk, int? theNumber)
        //{

        //}

        //public void DoStuff2(bool IsOk, int theNumber = 1)
        //{
        //    var myOutput = true;
        //    var doStuff = DetermineIfInt("", out myOutput);
        //}

        //public int DetermineIfInt(string potentialNumber, out bool isValid)
        //{
        //    isValid = false;
        //    return 0;
        //}






    }
}