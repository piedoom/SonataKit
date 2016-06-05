using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System.Diagnostics;
using HtmlAgilityPack;
using System.IO;

namespace SonataKit
{
    public static class Client
    {
        private static RestClient restClient = new RestClient();
        private static RestClient wikiClient = new RestClient();
        private static Uri wikiBase = new Uri("http://wiki.starsonata.com/index.php");

        /// <summary>
        /// get and deserialize our universe JSON data
        /// </summary>
        /// <param name="universeAPI">API link.  Defaults to http://www.starsonata.com/ss_api/universe.json </param>
        public async static Task<List<Galaxy>> BuildUniverse(
            string universeAPI = "http://www.starsonata.com/ss_api/universe.json")
        {
            // get the universe JSON
            restClient.BaseUrl = new Uri(universeAPI);
            var request = new RestRequest(Method.GET);
            var result = await restClient.Execute(request);

            // serialize it into C# objects
            return Universe.GetListFromJSON(result.Content);
        }

        public async static Task<List<Weapon>> GetWeapons()// Task<List<Weapon>> GetWeapons()
        {
            wikiClient.BaseUrl = wikiBase;
            var request = new RestRequest("Weapons/Complete", Method.GET);
            var result = await wikiClient.Execute(request);

            // we'll use a semantic zoom control for this in most situations
            // Okay, lets parse some stuff.

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result.Content);

            // get the weapons table
            IEnumerable<HtmlNode> tables = htmlDoc.GetElementbyId("content").Descendants("table");

            // create our list of weapons
            List<Weapon> weaponsList = new List<Weapon>();

            // loop over each table (even though there is just one)
            foreach (HtmlNode table in tables)
            {
                // loop over each row in table (which corresponds to each weapon)
                foreach (HtmlNode row in table.Descendants("tr"))
                {
                    // create temporary list for our data
                    List<string> rowEntry = new List<string>();
                    foreach (HtmlNode data in row.Descendants("td"))
                    {
                        rowEntry.Add(data.InnerText);
                    }

                    // create our weapon
                    try
                    {
                        var wep = new Weapon(rowEntry);
                        weaponsList.Add(wep);
                    }
                    catch
                    // if some random error, skip this weapon
                    {
                        break;
                    }                                    
                }
            }

            return weaponsList;

        }

    }
}








