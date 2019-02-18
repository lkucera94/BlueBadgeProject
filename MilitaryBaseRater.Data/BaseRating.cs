using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Data
{
    public class BaseRating
    {
        [Key]
        public int RatingID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public int BaseID { get; set; }
        [Required]
        public int RaterID { get; set; }

        public virtual Base Base { get; set; }

        public virtual Rater Rater { get; set; } 

        [Required]
        [Display(Name = "Overall Rating (Out of 10)")]
        public decimal OverallRating { get; set; }
        [Required]
        [Display(Name = "Housing Rating (Out of 10)")]
        public decimal HousingRating { get; set; }
        [Required]
        [Display(Name = "Food Rating (Out of 10)")]
        public decimal FoodRating { get; set; }
        [Required]
        [Display(Name = "Activities Rating (Out of 10)")]
        public decimal ActivitiesRating { get; set; }
        [Required]
        [Display(Name = "Training Sites Rating (Out of 10)")]
        public decimal TrainingSitesRating { get; set; }

        public string Comments { get; set; }

    }
}
