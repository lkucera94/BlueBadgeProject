using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RatingModels
{
    public class RatingCreate
    {
        [Required]
        public int BaseID { get; set; }
        [Required]
        public int RaterID { get; set; }
        [Required]
        public decimal OverallRating { get; set; } 
        [Required]
        public decimal HousingRating { get; set; }
        [Required]
        public decimal FoodRating { get; set; }
        [Required]
        public decimal ActivitiesRating { get; set; }
        [Required]
        public decimal TrainingSitesRating { get; set; }
         
        public string Comments { get; set; }
    }
}
