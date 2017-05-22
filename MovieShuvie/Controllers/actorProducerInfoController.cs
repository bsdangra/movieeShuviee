using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShuvie.ViewModels;
using MovieShuvie.Models;

namespace MovieShuvie.Controllers
{
    public class actorProducerInfoController : Controller
    {
        // GET: actorProducerInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult actorInfo(string actorName)
        {
            movieBLC blc = new movieBLC();
            List<actors> actr = blc.getActors(actorName);            
                ViewData["actor"] = actr[0];
                return View("actorInfo");
                       
        }

        public ActionResult producerInfo(string producerName)
        {
            movieBLC blc = new movieBLC();
            List<producers> prod = blc.getProducers(producerName);       
                ViewData["producer"] = prod[0];
                return View("producerInfo");
            
            
            
        }
    }
}