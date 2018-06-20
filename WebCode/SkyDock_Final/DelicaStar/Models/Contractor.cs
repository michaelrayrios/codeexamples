using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SkyDock.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyDock.Models
{
    public class Contractor
    {
        [Key]
        public int ContractorID { get; set; } //PK
        public int FlightID { get; set; }

        //Properties
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Contractor_Name_First { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Contractor_Name_Last { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Contractor_Organization { get; set; }


        public string Contractor_Details { get; set; }

        //Built description
        public string Contractor_Description { get { return Contractor_Name_First + " " + Contractor_Name_Last + " on behalf of " + Contractor_Organization; } }
    }
}
