using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class lab3
    {
        static void Main(string[] args)
        {
            object[] ListOfFlights = new object[7] { new Airline("Mogilev", 3, 'A', Airline.weekDays.fri),
                                                     new Airline("Kiev", 666),
                                                     new Airline(),
                                                     new Airline(),
                                                     new Airline("Kiev", 1, 'Z', Airline.weekDays.mon),
                                                     new Airline("Moskva",69),
                                                     new Airline("Minsk", 9)
                                                    };
            Airline.showInf();

            Console.WriteLine("Список рейсов для Kiev: ");
            foreach(Airline flight in ListOfFlights)
            {
                if (flight.DESTINATION == "Kiev")
                    Console.WriteLine(flight.NUMOFFLIGHT + "\t" + flight.TYPEOFPLANE + "\t" + flight.DESTINATION + "___________________" + flight.SEASON);
            }
            Console.WriteLine("Список рейсов в воскресенье: ");
            foreach(Airline flight in ListOfFlights)
            {
                if(flight.DAY == Airline.weekDays.sun)
                    Console.WriteLine(flight.NUMOFFLIGHT + "\t" + flight.TYPEOFPLANE + "\t" + flight.DESTINATION + "___________________" + flight.SEASON);
            }
        }
    }

    public partial class Airline
    {
        private static int tableSize = 0;
        public static void showInf()
        {
            Console.WriteLine("Size: " + tableSize);
        }
        private string destination = "";
        private int numOfFlight = 0;
        private char typeOfPlane = '\0';
        DateTime time = DateTime.Now;
        public enum weekDays
        {
            sun = 1, mon, thue, wen, thir, fri, sat
        }
        private weekDays wd = weekDays.mon;
        private readonly uint flightID;
        private const string season = "winter";

        public string DESTINATION
        {
            get { return this.destination; }
            set { this.destination = value != "Gomel" ? value : "error"; }
        }
        public int NUMOFFLIGHT
        {
            get { return this.numOfFlight; }
            set { this.numOfFlight = value != 5 ? value : -1; }
        }
        public char TYPEOFPLANE
        {
            get { return this.typeOfPlane; }
            set { this.typeOfPlane = value != '\0' ? value : 'E'; }
        }
        public string SEASON
        {
            get { return season; }
        }
        public weekDays DAY
        {
            get { return this.wd; }
            set { this.wd = value; }
        }


        static Airline()                                                                //static constructor
        {
            Console.WriteLine("Static Constructor is working");
        }
        public Airline()                                                                //first constructor
        {
            this.destination = "Minsk";
            this.numOfFlight = 1;
            this.typeOfPlane = 'A';
            this.wd = weekDays.sun;
            this.flightID = makeHash(destination, numOfFlight, typeOfPlane, wd);
            Airline.tableSize++;
        }
        public Airline(string dest, int flight)                                         //second constructor
        {
            this.destination = dest;
            this.numOfFlight = flight;
            this.typeOfPlane = 'A';
            this.wd = weekDays.sun;
            this.flightID = makeHash(destination, numOfFlight, typeOfPlane, wd);
            Airline.tableSize++;
        }
        public Airline(string dest, int flight, char type, weekDays day)                                         //third constructor
        {
            this.destination = dest;
            this.numOfFlight = flight;
            this.typeOfPlane = type;
            this.wd = day;
            this.flightID = makeHash(destination, numOfFlight, typeOfPlane, wd);
            Airline.tableSize++;
        }
        private Airline(string dest)                                                    //private constuctor
        {
            this.destination = dest;
            this.flightID = makeHash(destination, numOfFlight, typeOfPlane, wd);
            Airline.tableSize++;
        }
        public void showHidConstr()                                                     //use private constructor
        {
            Airline i = new Airline("Vtebsk");
        }
    }
}
