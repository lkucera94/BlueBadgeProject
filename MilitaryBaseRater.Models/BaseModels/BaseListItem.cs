using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.BaseModels
{
    public class BaseListItem
    {
        public int BaseID { get; set; }
        [Display(Name ="Base Name")]
        public string BaseName { get; set; } 
    }
}
