using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlexMovies.Models
{
    public class FlexMoviesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FlexMoviesContext() : base("name=FlexMoviesContext")
        {
        }

        public System.Data.Entity.DbSet<FlexMovies.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<FlexMovies.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<FlexMovies.Models.List> Lists { get; set; }

        public System.Data.Entity.DbSet<FlexMovies.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<FlexMovies.Models.BoughtMovie> BoughtMovies { get; set; }

        public System.Data.Entity.DbSet<FlexMovies.Models.RentedMovie> RentedMovies { get; set; }
    }
}
