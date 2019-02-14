using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.BaseModels
{
    public class BaseCreate
    {
        [Required]
        [Display(Name ="Base Name")]
        public string BaseName { get; set; }

        [Required]
        [Display(Name = "Base City")]
        public string BaseCity { get; set; }

        [Required]
        [Display(Name = "Base State")]
        public string BaseState { get; set; } 
    }
}
