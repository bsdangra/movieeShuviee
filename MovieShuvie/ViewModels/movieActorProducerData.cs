using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShuvie.ViewModels
{
    public class movieActorProducerData
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public string[] actorName { get; set; }
        public string producerName { get; set; }
        public string moviePlot { get; set; }
        public string imagePath { get; set; }
        public string yor { get; set; }
    }
}