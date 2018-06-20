using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SkyDock.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyDock.Models
{
    public class Charter
    {
        [Key]
        public int CharterID { get; set; } //PK
        public int FlightID { get; set; }

        //Properties
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Charter_Name_First { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Charter_Name_Last { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Charter_Organization { get; set; }

        public string Charter_Details { get; set; }


        //Built description
        public string Charter_Description { get { return Charter_Name_First + " " + Charter_Name_Last + " on behalf of " + Charter_Organization; } }
    }
}
