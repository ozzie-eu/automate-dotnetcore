using System;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;

namespace web_scrape_table
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.tiobe.com/tiobe-index/";
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            HtmlNode table = doc.DocumentNode.SelectSingleNode("//*[@id='top20']");

            var rows = table.Descendants("tr");

            List<string> lines = new List<string>();

            foreach (HtmlNode tr in table.Descendants("tr"))
            {
                string line = "";

                foreach(var node in tr.ChildNodes)
                {
                    if (node.Name != "td")
                        continue;
            
                    line += node.InnerText +";";
                }
                lines.Add(line);
            }

            File.WriteAllLines("tiobe.csv", lines);
        }
    }
}
