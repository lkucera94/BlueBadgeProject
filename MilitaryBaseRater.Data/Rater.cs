using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Data
{
    public class Rater
    {
        [Key]
        public int RaterID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string UserName { get; set; }
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
