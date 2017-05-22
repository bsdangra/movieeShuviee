using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShuvie.Models;

namespace MovieShuvie.ViewModels
{
    public class actorProducerList
    {
        public List<actors> actorsList { get; set; }
        public List<producers> producersList { get; set; }
    }
}