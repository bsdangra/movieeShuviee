using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieShuvie.Models;
using System.Data.SqlClient;
using System.Data;


namespace MovieShuvie.DataAcessLayer
{
    public class movieDAL: DbContext
    {
        public DbSet<movies> Movies { get; set; }
        public DbSet<actors> Actors { get; set; }
        public DbSet<producers> Producers { get; set; }
        public DbSet<movieNActor> MovieNActor { get; set; }
        public DbSet<movieNProducer> MovieNProducer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<movies>().ToTable("movies");
            modelBuilder.Entity<actors>().ToTable("actors");
            modelBuilder.Entity<producers>().ToTable("producers");
            modelBuilder.Entity<movieNActor>().ToTable("movieNActor");
            modelBuilder.Entity<movieNProducer>().ToTable("movieNProducer");
            base.OnModelCreating(modelBuilder);
        }

        public void enterDataDAL(string movieName, List<string> actorName, string producerName)
        {
            using (movieDAL dal = new movieDAL())
            {
                var prodId = dal.Producers.SqlQuery("Select * from producers where producerName=@p0", producerName).ToList<producers>(); //working
                var movieId = dal.Movies.SqlQuery("Select * from movies where movieName =@p0", movieName).ToList<movies>(); //working
                dal.Database.ExecuteSqlCommand("insert into movieNProducer(movieId, producerId) values(" + movieId[0].movieId + "," + prodId[0].producerId + ")");
                               
                foreach(string actor in actorName)
                {
                    var actorId = dal.Actors.SqlQuery("Select * from actors where actorName=@p0", actor).ToList<actors>();
                    dal.Database.ExecuteSqlCommand("insert into movieNActor(movieId, actorId) values(" + movieId[0].movieId + "," + actorId[0].actorId + ")");
                }
            }           
        }

        public DataTable getMovieList()
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=movieIMDB;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "get_movieList";
            //add any parameters the stored procedure might require
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }

        public void deleteDataDAL(int movieId) {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=movieIMDB;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_deleteData";
            cmd.Parameters.AddWithValue("@movieId", movieId);
            //add any parameters the stored procedure might require
            conn.Open();
            object obj = cmd.ExecuteScalar();            
            conn.Close();
        }

        public DataSet editDataDAL(int movieId) {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=movieIMDB;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_editData";
            cmd.Parameters.AddWithValue("@movieId", movieId);
            //add any parameters the stored procedure might require
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            return ds;
        }

        public void enterEditDataDAL(movies movie, List<actors> actors, List<actors> newActors, producers producer) {
            using (movieDAL dal = new movieDAL())
            {
                //dal.Database.ExecuteSqlCommand("insert into movieNProducer(movieId, producerId) values(" + movieId[0].movieId + "," + prodId[0].producerId + ")");

                var sqlMovie = @"Update movies set movieName = {0}, yor = {1}, plot = {2}, path = {3} where movieId = {4}";
                dal.Database.ExecuteSqlCommand(sqlMovie, movie.movieName, movie.yor, movie.plot, movie.path, movie.movieId);

                var sqlProducer = @"Update producers set producerName = {0}, producerSex = {1}, producerDOB = {2}, producerInfo = {3} where producerId = {4}";
                dal.Database.ExecuteSqlCommand(sqlProducer, producer.producerName, producer.producerSex, producer.producerDOB, producer.producerInfo, producer.producerId);
                               

                foreach (actors actor in actors)
                {
                    var sqlActor = @"Update actors set actorName = {0}, actorSex = {1}, actorDOB = {2}, actorInfo = {3} where actorId = {4}";
                    dal.Database.ExecuteSqlCommand(sqlActor, actor.actorName, actor.actorSex, actor.actorDOB, actor.actorInfo, actor.actorId);                                        
                }
                foreach(actors actor in newActors)
                {
                    dal.Database.ExecuteSqlCommand("insert into actors(actorName, actorSex, actorDOB, actorInfo) values('" + actor.actorName + 
                        "','" + actor.actorSex + "','" + actor.actorDOB + "','" + actor.actorInfo + "')");
                                     
                    var actorId = dal.Actors.SqlQuery("Select * from actors where actorName=@p0", actor.actorName).ToList<actors>();
                    dal.Database.ExecuteSqlCommand("insert into movieNActor(movieId, actorId) values(" + movie.movieId + "," + actorId[0].actorId + ")");
                }

            }
        }
    }
}