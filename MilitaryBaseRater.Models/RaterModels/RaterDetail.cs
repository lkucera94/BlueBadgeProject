using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Models.RaterModels
{
   public class RaterDetail
    {
        public int RaterID { get; set; }

        public string UserName { get; set; }

        public string Branch { get; set; }
        
        public string Job { get; set; }
        
        public string Rank { get; set; }
        
        public int Age { get; set; }
    }
}
