using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlexMovies.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]
        public double CreditCardNum { get; set; }
        [Required]
        public int CCSecCode { get; set; }
        [Required]
        public int ExpMonth { get; set; }
        [Required]
        public int ExpYear { get; set; }
        public int AccountNumber { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int TotalMoviesRented { get; set; }
        public double TotalAmountRented { get; set; }
        public double TotalAmountBought { get; set; }
               
        [ForeignKey("RentedMovie")]
        public int RentedMovieID { get; set; }
        public virtual ICollection<RentedMovie> RentedMovies { get; set; }

        [ForeignKey("BoughtMovie")]
        public int BoughtMovieID { get; set; }
        public virtual ICollection<BoughtMovie> BoughtMovies { get; set; }

    }
}