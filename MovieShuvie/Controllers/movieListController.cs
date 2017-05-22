using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShuvie.Models;
using MovieShuvie.ViewModels;
using System.IO;
using System.Data;

namespace MovieShuvie.Controllers
{
    public class movieListController : Controller
    {
        // GET: movieList
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create() {           

            movieBLC blc = new movieBLC();
            // for actors and producers already present in database
            actorProducerList actrProdList = new actorProducerList();
            actrProdList.actorsList = blc.getActors();
            actrProdList.producersList = blc.getProducers();

            return View("Create", actrProdList);
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, movies movie, producers producer,
            List<string> actorName, List<string> actorSex, List<DateTime> actorDOB, 
            List<string> actorInfo, string BtnSubmit, List<string> actorsDB, string producersDB)
        {
            try
            {
                
                List<actors> actorList = new List<actors>();
                for (int i = 0; i < actorName.Count; i++)
                {
                    if (actorName[i] != null && actorName[i] != String.Empty) {
                        actors act = new actors();
                        act.actorName = actorName[i];
                        act.actorSex = actorSex[i];
                        act.actorDOB = actorDOB[i];
                        act.actorInfo = actorInfo[i];
                        actorList.Add(act);
                    }
                }
                
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    movie.path = "/UploadedFiles/" + _FileName;
                    ////dump into database
                    switch (BtnSubmit)
                    {
                        case "Save Details":
                            movieBLC blc = new movieBLC();
                            blc.enterDataBLC(movie, producer, actorList, actorsDB, producersDB);
                            return RedirectToAction("Read", "movieList");
                        case "Cancel":
                            return RedirectToAction("Create");
                    }
                    return new EmptyResult();
                }
                ViewBag.Message = "File Upload failed!!";
                return RedirectToAction("Create", "movieList");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();                
                
            }
            
        }

        public ActionResult Read()
        {
            movieBLC movieBLC = new movieBLC();         
            DataTable dt = movieBLC.getMoviesList();

            if (dt.Rows.Count > 0)
            {
                List<movieActorProducerData> movActProdDataList = new List<movieActorProducerData>();
                movieActorProducerList movActProdList = new movieActorProducerList();
                foreach (DataRow row in dt.Rows)
                {
                    movieActorProducerData movActProdData = new movieActorProducerData();
                    movActProdData.movieId = Convert.ToInt32(row["movieId"]);
                    movActProdData.movieName = row["movieName"].ToString();
                    movActProdData.actorName = row["actorName"].ToString().Split(',');
                    movActProdData.producerName = row["producerName"].ToString();
                    movActProdData.moviePlot = row["moviePlot"].ToString();
                    movActProdData.imagePath = row["imagePath"].ToString();
                    movActProdData.yor = row["yor"].ToString();

                    movActProdDataList.Add(movActProdData);
                }

                movActProdList.movActProdDataList = movActProdDataList;

                return View("Read", movActProdList);
            }
            else
            {
                return RedirectToAction("Create", "movieList");
            }

            
        }


        [HttpGet]
        public ActionResult Update(int movieId)
        {
            movieBLC blc = new movieBLC();
            DataSet ds = blc.editData(movieId);
            DataTable movieDT = ds.Tables[0];
            DataTable actorsDT = ds.Tables[1];
            DataTable producerDT = ds.Tables[2];

            editData edata = new editData();

            foreach (DataRow row in movieDT.Rows)
            {
                movies movie = new movies();
                movie.movieId = Convert.ToInt32(row["movieId"]);
                movie.movieName = row["movieName"].ToString();
                movie.plot = row["plot"].ToString();
                movie.path = row["path"].ToString();
                movie.yor = Convert.ToInt32(row["yor"]);
                edata.movie = movie;
            }

            List<actors> act = new List<actors>();
            foreach(DataRow row in actorsDT.Rows)
            {
                actors actor = new actors();
                actor.actorDOB = Convert.ToDateTime(row["actorDOB"]);
                actor.actorId = Convert.ToInt32(row["actorId"]);
                actor.actorInfo = row["actorInfo"].ToString();
                actor.actorName = row["actorName"].ToString();
                actor.actorSex = row["actorSex"].ToString();
                act.Add(actor);                
            }
            edata.actors = act;

            foreach (DataRow row in producerDT.Rows)
            {
                producers producer = new producers();
                producer.producerDOB = Convert.ToDateTime(row["producerDOB"]);
                producer.producerId = Convert.ToInt32(row["producerId"]);
                producer.producerInfo = row["producerInfo"].ToString();
                producer.producerName = row["producerName"].ToString();
                producer.producerSex = row["producerSex"].ToString();
                edata.producer = producer;
            }

            return View("Update", edata);
        }


        [HttpPost]
        public ActionResult Update(HttpPostedFileBase file, movies movie, producers producer, List<string> actorName,
            List<int> actorId, List<string> actorSex, List<DateTime> actorDOB, 
            List<string> actorInfo, string BtnSubmit) {

            List<actors> actorList = new List<actors>();
            List<actors> newActorList = new List<actors>();

            int tempCount = actorId.Count;

            for (int i = 0; i < actorName.Count; i++)
            {
                if (actorName[i] != null && actorName[i] != String.Empty)
                {
                    actors act = new actors();
                    act.actorName = actorName[i];
                    act.actorSex = actorSex[i];
                    act.actorDOB = actorDOB[i];
                    act.actorInfo = actorInfo[i];
                    
                    if (i < tempCount)
                        actorList.Add(act);
                    else
                        newActorList.Add(act);                    
                }
            }

            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                file.SaveAs(_path);
                movie.path = "/UploadedFiles/" + _FileName;
                
                switch (BtnSubmit)
                {
                    case "Save Employee":
                        movieBLC blc = new movieBLC();
                        blc.enterEditData(movie, actorList, newActorList, producer);
                        return RedirectToAction("Read", "movieList");
                    case "Cancel":
                        return RedirectToAction("Index");
                }
                return new EmptyResult();
            }
            ViewBag.Message = "File Upload Failed!!";
            return RedirectToAction("Read", "movieList");
        }

        public ActionResult Delete(int movieId)
        {
            movieBLC blc = new movieBLC();
            blc.deleteData(movieId);
            return RedirectToAction("Read", "movieList");
        }
    }
}