using System.Collections.Generic;

namespace DATAGOV_API_INTRO_8.Models
{
    public class Analytic
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string parkCode { get; set; }
        public string description { get; set; }
        public string latLong { get; set; }
    }

    public class Analytics
    {
        public List<Analytic> data { get; set; }
    }
}