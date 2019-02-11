using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RaterModels
{
    public class RaterEdit
    {
        [Required]
        public int RaterID { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public string Rank { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
