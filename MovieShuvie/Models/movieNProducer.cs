using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShuvie.Models
{
    public class movieNProducer
    {
        [Key]
        [Column(Order = 1 )]
        public int movieId { get; set; }

        [Key]
        [Column(Order = 2 )]
        public int producerId { get; set; }

        [ForeignKey("movieId")]
        public movies movie { get; set; }

        [ForeignKey("producerId")]
        public producers producer { get; set; }
    }
}