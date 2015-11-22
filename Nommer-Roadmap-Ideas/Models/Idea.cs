using System.Collections.Generic;

namespace Github_Idea_Lodger.Models
{
    public class Idea
    {
        public string title { get; set; }

        public string description { get; set; }

        public List<string> labels { get; set; }
    }
}
