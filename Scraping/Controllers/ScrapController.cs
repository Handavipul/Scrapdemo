using HtmlAgilityPack;
using Scraping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace Scraping.Controllers
{
    public class ScrapController : ApiController
    {
        [HttpGet]
        public reviewSummary GetUrlSource(string url)
        {
            url = url.Substring(0, 4) != "http" ? "http://" + url : url;
            string htmlCode = "";
            Review rvw;
            reviewSummary rs = new reviewSummary();


            using (WebClient client = new WebClient())
            {
                try
                {
                    htmlCode = client.DownloadString(url);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(htmlCode);
                    HtmlNode nodeAvg = doc.DocumentNode.SelectSingleNode("//div[@class='webmd-rate on-desktop pointer']");
                    HtmlNode nodeTotalReviews = doc.DocumentNode.SelectSingleNode("//span[@class='webmd-rate--number']");
                    HtmlNode nodeReviews = doc.DocumentNode.SelectSingleNode("//div[@class='reviews-rating']");
                    var SubnodesParent = nodeReviews.FirstChild.ChildNodes;

                    rs.success = "true";
                    rs.status = 200;
                    rs.job_id = 434343;
                    rs.source_url = url;
                    rs.place_id = "eee";
                    rs.external_indentifier = null;
                    rs.meta_data = "{3434/34/3/0}";
                    rs.unique_id = "";
                    rs.review_count = nodeTotalReviews.InnerText;//nodes.Where(n=>n.HasClass("webmd-row")).Count();
                    rs.average_rating = nodeAvg.Attributes["aria-valuenow"].Value;


                    foreach (HtmlAgilityPack.HtmlNode node in SubnodesParent)
                    {
                        rvw = new Review();
                        var reviewRate = node.SelectSingleNode("//div[@class='webmd-rate']");
                        var reviewData = node.InnerText;
                        var reviewDate = node.SelectSingleNode("//li[@class='reviewdate date-separator']");
                        var reviewFrom = node.SelectSingleNode("//span[@class='review-from']").InnerText;
                        rvw.id = "ee";
                        rvw.name = "ee";
                        rvw.date = reviewDate.InnerText.ToString();
                        rvw.language_code = "ee0";
                        rvw.location = "ee0";
                        rvw.metadata = "ee0";
                        rvw.review_text = reviewData.ToString();
                        rvw.unique_id = "ee0";
                        rvw.url = reviewFrom.ToString();
                        rvw.verified_order = "ee0";
                        rvw.review_title = "ee0";
                        rvw.rating_value = "ee0";
                        rvw.reviewer_title = "ee0";
                        rvw.profile_picture = "ee0";
                        rs.Reviews.Add(rvw);

                    }
                    //https://localhost:44368/api/scrap/GetUrlSource?url=https://doctor.webmd.com/doctor/christina-teimouri-496c4ba6-60b4-4a4e-ac6e-76529c05e235-overview?lid=5325592



                }
                catch (Exception ex)
                {

                }
            }
            return rs;
        }
    }
}
