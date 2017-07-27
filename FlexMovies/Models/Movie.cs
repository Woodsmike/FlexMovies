using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlexMovies.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public double CostToBuy { get; set; }
        public double CostToRent { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }
        public double Earnings { get; set; }

        
        public virtual ICollection<List> Lists { get; set; }

        
        public virtual Genre Genre { get; set; }
    }
}