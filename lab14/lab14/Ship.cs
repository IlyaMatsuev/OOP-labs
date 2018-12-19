using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab14
{
    [Serializable]
    public class Ship : Object
    {
        [XmlAttribute]
        public double Carrying { get; set; }
        [XmlAttribute]
        public string CaptainName { get; set; }

        public virtual void GetVehicleInf() => Console.WriteLine($"Carrying: {Carrying}, Captain: {CaptainName}");
        public void ToWater() => Console.WriteLine("To search adventure");

        private Ship() { }
        public Ship(double Carrying, string CaptainName)
        {
            this.Carrying = Carrying;
            this.CaptainName = CaptainName;
        }

        public override string ToString() => base.ToString() + " - ToString in Ship";
        public override bool Equals(object obj) => !base.Equals(obj);
        public override int GetHashCode() => 0;
    }
}
