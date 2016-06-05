using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace SonataKit
{
    public class Universe
    {
        public List<Galaxy> Galaxies { get; set; }

        // should run this with a background worker 
        public static List<Galaxy> GetListFromJSON(string json)
        {
            // we need two universes since the api is weird
            var universeDict = JsonConvert.DeserializeObject<Dictionary<string, Galaxy>>(json);
            var universe = new List<Galaxy>();

            foreach (KeyValuePair<string, Galaxy> galaxy in universeDict)
            {
                // probably not the best way to do this, but whatever
                galaxy.Value.ID = galaxy.Key;
                universe.Add(galaxy.Value);
            }

            return universe;
        }
    }
}
