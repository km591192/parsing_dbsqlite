using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parsing_wf
{
    public class GetSet
    {
        // [PrimaryKey, AutoIncrement, Unique]
        public int id { get; set; }
        // [NotNull]
        public string url { get; set; }
        public string httpstatus { get; set; }
        public string statusdes { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string hrefTag { get; set; }
        public string imgTag { get; set; }
        public string h { get; set; }
        public string time { get; set; }

    }
}