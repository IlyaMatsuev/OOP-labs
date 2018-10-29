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
        private double delta;
        public double Delta { get { return delta; }
            set
            {
                if (value >= 1)
                    throw new VehicleException("Неверный коэфициент дельта", value);
                delta = value;
            }
        }
        private double carrying;
        public double Carrying { get { return carrying; }
            set
            {
                if (value <= 0)
                    throw new VehicleException("Неверное значение грузоподъемности", value);
                carrying = value;
            }
        }
        public string CaptainName { get; set; }
        public uint CaptainAge { get; set; }

        // Abstract method can't have implementation
        public abstract void Move();
        // Virtual can
        public virtual void GetVehicleInf() => Console.WriteLine($"Vehicle: {VehicleName}, Carrying: {Carrying}, Captain: {CaptainName}");
        public void ToWater() => Console.WriteLine("To search adventure");

        protected Ship(double Carrying, string CaptainName, uint CaptainAge, double Delta)
        {
            VehicleName = "Ship";
            this.Carrying = Carrying;
            this.CaptainName = CaptainName;
            this.CaptainAge = CaptainAge;
            this.Delta = Delta;
        }

        void ICaptain.OneNameMethod() => Console.WriteLine("Hi, i'm from Captain interface!");
        void IVehicle.OneNameMethod() => Console.WriteLine("Hi, i'm from Vehicle interface!");

        public override string ToString() => base.ToString() + " - ToString in Ship";
        public override bool Equals(object obj) => !base.Equals(obj);
        public override int GetHashCode() => 0;
    }
}
