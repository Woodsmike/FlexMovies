using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlexMovies.Models
{
    public class RentedMovie
    {
        [Key]
        public int RentedMovieID { get; set; }
        public double ReceiptNumber { get; set; }        
        public double CostToRent { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ExpirationDate { get; set; } //Date the movie stops streaming
        public int TimesRented { get; set; }

      
        public virtual ICollection<Account> Accounts { get; set; }

        
        public virtual List List { get; set; }
    }
}