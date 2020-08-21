using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scraping.Models
{
    public class reviewSummary
    {
        public reviewSummary()
        {
            Reviews = new List<Review>();
        }
        public string success { get; set; }
        public int status { get; set; }
        public int job_id { get; set; }
        public string source_url { get; set; }
        public string place_id { get; set; }
        public string external_indentifier { get; set; }
        public string meta_data { get; set; }
        public string unique_id { get; set; }
        public string review_count { get; set; }
        public string average_rating { get; set; }

        public List<Review> Reviews { get; set; }
    }
}