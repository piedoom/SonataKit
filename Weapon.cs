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
        public string Damage { get; set; }
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
        public string Parasite { get; set; }
        public string BeamComments { get; set; }

        public Weapon(List<string> data)
        {
            Name = data.ElementAt(0);
            Tech = int.Parse(data.ElementAt(1));
            Size = int.Parse(data.ElementAt(2));
            Damage = data.ElementAt(3);
            Range = double.Parse(data.ElementAt(4));
            Recoil = double.Parse(data.ElementAt(5));
            Electricity = double.Parse(data.ElementAt(6));
            Weight = double.Parse(data.ElementAt(7));
            Parasite = data.ElementAt(8);
            DamagePerSecond = double.Parse(data.ElementAt(9));
            ElectricityPerSecond = double.Parse(data.ElementAt(10));
            DamagePerElectricity = double.Parse(data.ElementAt(11));
            Source = data.ElementAt(12);
            Description = data.ElementAt(13);
            Comments = data.ElementAt(14);
            BeamComments = data.ElementAt(15);
        }

    }
}
