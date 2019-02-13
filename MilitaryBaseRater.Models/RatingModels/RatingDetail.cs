using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RatingModels
{
    public class RatingDetail
    {
        public int RatingID { get; set; } 
         
        public decimal OverallRating { get; set; }
        
        public decimal HousingRating { get; set; }
        
        public decimal FoodRating { get; set; }
        
        public decimal ActivitiesRating { get; set; }
        
        public decimal TrainingSitesRating { get; set; }

        public string Comments { get; set; } 
    }
}
