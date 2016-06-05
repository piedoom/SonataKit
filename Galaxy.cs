using System.Collections.Generic;
using Newtonsoft.Json;

namespace SonataKit
{

    // maybe an enum isn't the best for this...
    public enum GalaxyLayer
    {
        Earthforce,
        Unused1, Unused2,
        WildSpace,
        PerilousSpace,
        Subspace,
        Unused6, Unused7, Unused8, Unused9,
        Nexus,
        ColorEmpires,
        Serengeti,
        Nihilite,
        Unused14,
        Absolution,
        EnigmaticSector,
        IqBana,
        Olympus,
        Liberty,
        SubspaceInstances,
        Arctia,
        Vulcan,
        SuqqBana,
        Jungle,
        Unused25, Unused26, Unused27, Unused28, Unused29, Unused30, Unused31, Unused32, Unused33, Unused34,
        Kidd,
        Holiday
    }

    // http://wiki2.starsonata.com/index.php/APIs_and_data_end_points   


    public class Galaxy
    {
        // set up some properties
        // API: top level object
        //[JsonProperty("eighty_min_score")]
        public string ID { get; set; }

        // array of galaxy IDs that are connected
        // API: 'w'
        [JsonProperty("w")]
        public List<string> Connections { get; set; }

        // galaxy name
        // API: 'n'
        [JsonProperty("n")]
        public string Name { get; set; }

        // danger factor
        // API: 'df'
        [JsonProperty("df")]
        public string DangerFactor { get; set; }

        // Is the galaxy an Anchor Galaxy?
        [JsonProperty("a")]
        public bool IsAnchor { get; set; }

        // Is the galaxy a special Galaxy?
        [JsonProperty("s")]
        public bool IsSpecial { get; set; }

        // Number of user bases in the Galaxy
        [JsonProperty("u")]
        public int UserBaseCount { get; set; }

        // Number of space stations in the Galaxy
        [JsonProperty("b")]
        public int SpaceStationCount { get; set; }

        // Name of owning team, if it exists
        [JsonProperty("t")]
        public string OwningTeam { get; set; }

        // Is this galaxy owned?
        [JsonProperty("o")]
        public bool IsOwned { get; set; }

        // Is this galaxy protected?
        [JsonProperty("p")]
        public bool IsProtected { get; set; }

        // coordinates
        // API: 'x, y'
        [JsonProperty("x")]
        public float X { get; set; }

        [JsonProperty("y")]
        public float Y { get; set; }

        // layer    
        [JsonProperty("l")]
        private int layer { get; set; }
        public GalaxyLayer Layer {
            get
            {
                return (GalaxyLayer)layer;
            }
            set
            {
                value = (GalaxyLayer)layer;
            }
        }

        public System.Numerics.Vector2 Xy { get; set; }

        public System.Numerics.Vector2 GetOrigin(float xOffset = 0, float yOffset = 0, float scale = 1)
        {
            
            Xy = new System.Numerics.Vector2((X * scale) + xOffset, (Y * scale) + yOffset);
            return Xy;            
        }
    } 
}
