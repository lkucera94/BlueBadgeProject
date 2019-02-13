using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RaterModels
{
    public class RaterListItem
    {
        public int RaterID { get; set; } 

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Branch { get; set; }

        [Display(Name ="Job/Position")]
        public string Job { get; set; }
       
        public string Rank { get; set; }
        
        public int Age { get; set; }
    }
}
