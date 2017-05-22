using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieShuvie.Models
{
    public class actors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int actorId { get; set; }
        public string actorName { get; set; }
        public string actorSex { get; set; }
        public DateTime actorDOB { get; set; }
        public string actorInfo { get; set; }
    }
}