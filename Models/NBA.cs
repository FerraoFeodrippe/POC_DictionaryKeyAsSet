using System;
using System.Collections.Generic;
using System.Text;

namespace POC_SetToRules.Models
{
    public class NBA
    {
        public string ID { get; set; }
        public string NBAType { get; set; }
        public IEnumerable<NBAAction> Actions {get; set;}
    }
}
