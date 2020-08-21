using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scraping.Models
{
    public class Review
    {
        //public Review(string _id, string _name, string _date, string _rating_value, string _profile_picture, string _location, string _review_title)
        //{
        //    id = _id;
        //    name = _name;
        //    date = _date;
        //    rating_value = _rating_value;
        //    profile_picture = _profile_picture;
        //    location = _location;
        //    reviewer_title = _review_title;

        //}
        public string id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string rating_value { get; set; }
        public string review_text { get; set; }
        public string url { get; set; }
        public string profile_picture { get; set; }
        public string location { get; set; }
        public string review_title { get; set; }
        public string verified_order { get; set; }
        public string reviewer_title { get; set; }
        public string language_code { get; set; }
        public string unique_id { get; set; }
        public string metadata { get; set; }

    }
}