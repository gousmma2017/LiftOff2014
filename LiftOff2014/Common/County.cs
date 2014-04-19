using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiftOff2014.Common
{
    public class County
    {
        public int CountyID { get; set;  }

        public string CountyName { get; set;  }

        public int TotalVotes { get; set; }

        public int ProjectedVotes { get; set; }
    }
}