using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShuvie.Models
{
    public class producers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int producerId { get; set; }
        public string producerName { get; set; }
        public string producerSex { get; set; }
        public DateTime producerDOB { get; set; }
        public string producerInfo { get; set; }
    }
}