using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RatingModels
{
    public class RatingListItem
    {
        public int RatingID { get; set; }
        public int BaseID { get; set; }
        public decimal OverallRating { get; set; }
        public string BaseName { get; set; }
    }
}
