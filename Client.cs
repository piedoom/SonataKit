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

        public async static void GetWeapons()// Task<List<Weapon>> GetWeapons()
        {
            wikiClient.BaseUrl = wikiBase;
            var request = new RestRequest("Weapons", Method.GET);
            var result = await wikiClient.Execute(request);

            // time to parse out our tables!  Unfortunately, the best way I can see to do this is actually go through HTML.
            // our tables should stay in order for each type.
            // 1 - Energy Weapons
            // 2 - Parasite Weapons
            // 3 - Heat Weapons
            // 4 - Laser Weapons
            // 5 - Mining Weapons
            // 6 - Physical Weapons
            // 7 - Radiation Weapons
            // 8 - Surgical Weapons
            // 9 - Transference Weapons

            // we'll use a semantic zoom control for this in most situations
            // Okay, lets parse some stuff.

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result.Content);

            // get all tables
            IEnumerable<HtmlNode> tables = htmlDoc.GetElementbyId("content").Descendants("table");

            // create our list of weapons
            List<Weapon> weaponsList = new List<Weapon>();

            // loop over each table
            foreach (HtmlNode table in tables)
            {
                // make sure we skip the table of contents
                if (table.Id != "toc")
                {
                    // loop over each row in table (which corresponds to each weapon)
                    foreach (HtmlNode row in table.Descendants("tr"))
                    {
                        // create temporary list of items
                        List<string> rowEntry = new List<string>();

                        foreach (HtmlNode data in row.Descendants("td"))
                        {
                            rowEntry.Add(data.InnerText);
                        }

                        // create our weapon
                        try
                        {
                            var wep = new Weapon();
                            wep.Name = rowEntry.ElementAt(0);
                            wep.Tech = int.Parse(rowEntry.ElementAt(1));
                            wep.Size = Double.Parse(rowEntry.ElementAt(2));
                            wep.Damage = Double.Parse(rowEntry.ElementAt(3));
                            wep.Range = Double.Parse(rowEntry.ElementAt(4));
                            wep.Recoil = Double.Parse(rowEntry.ElementAt(5));
                            wep.Electricity = Double.Parse(rowEntry.ElementAt(6));
                            wep.ElectricityPerSecond = Double.Parse(rowEntry.ElementAt(7));
                            wep.DamagePerElectricity = Double.Parse(rowEntry.ElementAt(8));
                            wep.Source = rowEntry.ElementAt(9);
                            wep.Description = rowEntry.ElementAt(10);
                            wep.Comments = rowEntry.ElementAt(11);

                            weaponsList.Add(wep);
                        }
                        catch
                        // if some random error, skip this weapon
                        {
                            break;
                        }
                            
                        
                    }
                }
            }


        }
    }
}







