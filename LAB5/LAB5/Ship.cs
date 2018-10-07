using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    abstract class Ship : Object, IVehicle, ICaptain
    {
        public string VehicleName { get; set; }
        public double Carrying { get; set; }
        public string CaptainName { get; set; }

        public string ShipType { get; }

        // Abstract method can't have implementation
        public abstract void Move();
        // Virtual can
        public virtual void GetVehicleInf() => Console.WriteLine($"Vehicle: {VehicleName}, Carrying: {Carrying}, Captain: {CaptainName}");
        public void ToWater() => Console.WriteLine("To search adventure");

        protected Ship(double Carrying, string CaptainName, string ShipType)
        {
            VehicleName = "Ship";
            this.Carrying = Carrying;
            this.CaptainName = CaptainName;
            this.ShipType = ShipType;
        }

        void ICaptain.OneNameMethod() => Console.WriteLine("Hi, i'm from Captain interface!");
        void IVehicle.OneNameMethod() => Console.WriteLine("Hi, i'm from Vehicle interface!");

        public override string ToString() => base.ToString() + " - ToString in Ship";
        public override bool Equals(object obj) => !base.Equals(obj);
        public override int GetHashCode() => 0;
    }
}
