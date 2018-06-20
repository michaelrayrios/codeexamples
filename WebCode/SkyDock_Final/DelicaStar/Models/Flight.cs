using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SkyDock.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyDock.Models
{
    public class Flight
    {
        private Charter flightCharter = new Charter();
        private Contractor flightContractor = new Contractor();

        [Key]
        public int FlightID { get; set; } //PK

        //Objects
        public Charter FlightCharter { get { return flightCharter; } set { flightCharter = value; } }
        public Contractor FlightContractor { get { return flightContractor; } set { flightContractor = value; } }

        //Properties
        [Required]
        [MinLength(2)]
        [MaxLength(250)]
        public string Flight_Purpose { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Flight_Origin { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Flight_Destination { get; set; }

        public string Flight_Details { get; set; }

        //Built description
        public string Flight_Title { get { return Flight_Purpose + ", " + Flight_Origin + " to " + Flight_Destination; } }
    }
}
