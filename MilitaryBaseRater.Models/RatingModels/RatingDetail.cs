using MilitaryBaseRater.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RatingModels
{
    public class RatingDetail
    {
        public int RatingID { get; set; }

       
        [Display(Name = "Overall Rating (Out of 10)")]
        public decimal OverallRating { get; set; }
       
        [Display(Name = "Housing Rating (Out of 10)")]
        public decimal HousingRating { get; set; }
        
        [Display(Name = "Food Rating (Out of 10)")]
        public decimal FoodRating { get; set; }
    
        [Display(Name = "Activities Rating (Out of 10)")]
        public decimal ActivitiesRating { get; set; }
      
        [Display(Name = "Training Sites Rating (Out of 10)")]
        public decimal TrainingSitesRating { get; set; }

        public string Comments { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Base Name")]
        public string BaseName { get; set; }

        public virtual Base Base { get; set; }

        public virtual Rater Rater { get; set; }

    }
}
