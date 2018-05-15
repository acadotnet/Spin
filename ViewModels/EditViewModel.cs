using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Models;

namespace Spin.ViewModels
{
    public class EditViewModel
    {
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public Songs Songs { get; set; }
        public Genre Genre { get; set; }
    }
}