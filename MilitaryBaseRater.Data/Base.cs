using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Data
{
   public class Base
    {
        [Key]
        public int BaseID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string BaseName { get; set; }
        [Required]
        public string BaseCity { get; set; }
        [Required]
        public string BaseState { get; set; }
    }
}
