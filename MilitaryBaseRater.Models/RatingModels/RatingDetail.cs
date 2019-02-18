﻿using System;
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

        public string Branch { get; set; }

        public string Job { get; set; }

        public string Rank { get; set; }

        public int Age { get; set; }

    }
}
