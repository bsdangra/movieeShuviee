using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShuvie.DataAcessLayer;
using System.Data;

namespace MovieShuvie.Models
{
    public class movieBLC
    {
        //  retrieve List of actors
        public List<actors> getActors(string actorName = null) {
            movieDAL dal = new movieDAL();
            try {
                if (actorName == null)
                {
                    return dal.Actors.ToList();
                }
                else
                {
                    var actor = dal.Actors.SqlQuery("Select * from actors where actorName=@p0", actorName).ToList<actors>();
                    return actor.ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        //  retrieve List of producers
        public List<producers> getProducers(string producerName = null) {
            movieDAL dal = new movieDAL();
            try {
                if (producerName == null)
                {
                    return dal.Producers.ToList();
                }
                else
                {
                    var producer = dal.Producers.SqlQuery("Select * from producers where producerName=@p0", producerName).ToList<producers>();
                    return dal.Producers.ToList();
                }
            }
            catch
            {
                return null;
            }
            

            
        }

        //get movies list to display
        public DataTable getMoviesList()
        {
            movieDAL dal = new movieDAL();
            DataTable dt = dal.getMovieList();
            return dt;
        }

        //delete movie
        public void deleteData(int movieId)
        {
            movieDAL dal = new movieDAL();
            dal.deleteDataDAL(movieId);
        }

        //get data related for a selected movie
        public DataSet editData(int movieID) {
            movieDAL dal = new movieDAL();
            DataSet ds = dal.editDataDAL(movieID);
            return ds;
        }

        //store new data
        public void enterDataBLC(movies movie, producers producer, List<actors> actor, List<string> actorsDB, string producersDB) {

            List<String> tmpActName = new List<string>();
            movieDAL dal = new movieDAL();

            if (!dal.Movies.Any(x => x.movieName.Contains(movie.movieName))) {

                dal.Movies.Add(movie);

                //to add producer
                if (producersDB == "" || producersDB == null )
                {
                    if (!dal.Producers.Any(x => x.producerName.Contains(producer.producerName)))
                    {
                        dal.Producers.Add(producer);
                    }

                }
                else
                {
                    producer.producerName = producersDB;
                }
                
                //for adding actors
                foreach (actors item in actor)
                {
                    tmpActName.Add(item.actorName);

                    if (! dal.Actors.Any(x => x.actorName.Contains(item.actorName)))
                    {
                        dal.Actors.Add(item);                    
                    }

                }
                if (actorsDB != null)
                {
                    tmpActName.AddRange(actorsDB);
                }
                
                //save to db
                if (dal.SaveChanges() > 0)
                {
                    dal.enterDataDAL(movie.movieName, tmpActName, producer.producerName);
                }

            }
        }

        public void enterEditData(movies movie, List<actors> actors, List<actors> newActors, producers producer) {
            movieDAL dal = new movieDAL();
            dal.enterEditDataDAL(movie, actors, newActors, producer);
        }
        
    }
}