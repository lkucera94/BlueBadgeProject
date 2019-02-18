using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RatingModels
{
    public class RatingListItem
    {
        public int RatingID { get; set; }
        public int BaseID { get; set; }

        [Display(Name = "Overall Rating (Out of 10)")]
        public decimal OverallRating { get; set; }

        [Display(Name = "Base Name")]
        public string BaseName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Branch { get; set; }

        public string Job { get; set; }

        public string Rank { get; set; }

        public int Age { get; set; }
    } 
}
