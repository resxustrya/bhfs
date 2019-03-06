using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFSRBO.Core
{
    public static class CommunicationViewModel
    {
        public static List<communication> communication = new List<communication>
        {
            new communication {ID = 1, desc = "By Photo" },
            new communication {ID = 2, desc = "By Mail" },
            new communication {ID = 3, desc = "By Interview walk-in" },
            new communication {ID = 4, desc = "By Social media" },
            new communication {ID = 5, desc = "By Postal Mail" },
            new communication {ID = 6, desc = "By Text Message" },
            new communication {ID = 7, desc = "By Interview" },
            new communication {ID = 8, desc = "By Email" },
            new communication {ID = 9, desc = "PCC" },
            new communication {ID = 10, desc = "Courier"}
        };
    }
}