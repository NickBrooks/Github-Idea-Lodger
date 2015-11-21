using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github_Idea_Lodger.Models
{
    public class Idea
    {
        public string title { get; set; }

        public string description { get; set; }

        public List<string> labels { get; set; }
    }
}
