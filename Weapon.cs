using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;

namespace SonataKit
{
    public class Weapon : Item
    {
        public double Damage { get; set; }
        public double Range { get; set; }
        public double Recoil { get; set; }
        public double Electricity { get; set; }
        public string Visibility { get; set; }
        public double DamagePerSecond { get; set; }
        public double ElectricityPerSecond { get; set; }
        public double DamagePerElectricity { get; set; }
        public string Source { get; set; }
        public string Comments { get; set; }
        public string ImageURL { get; set; }

    }
}
