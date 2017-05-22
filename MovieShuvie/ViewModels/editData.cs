using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShuvie.Models;

namespace MovieShuvie.ViewModels
{
    public class editData
    {
        public movies movie { get; set; }
        public List<actors> actors { get; set; }
        public producers producer { get; set; }
    }
}