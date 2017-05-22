using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShuvie.Models
{
    public class movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int movieId { get; set;}
        public string movieName { get; set; }
        public int yor { get; set; }
        public string plot { get; set; }
        public string path { get; set; }
    }
}