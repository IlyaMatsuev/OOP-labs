using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class Airline : IComparable
    {
        private static int tableSize = 0;
        public static void showInf() => Console.WriteLine("Size: " + tableSize);
        public void ShowDetail() => Console.WriteLine($"Dest: {DESTINATION}, flight: {NUMOFFLIGHT}, type: {TYPEOFPLANE}, day: {DAY}");

        private string destination = "";
        private int numOfFlight = 0;
        private char typeOfPlane = '\0';
        private weekDays wd = weekDays.mon;

        public enum weekDays
        {
            sun = 1, mon, thue, wen, thir, fri, sat
        }

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
        public weekDays DAY
        {
            get { return this.wd; }
            set { this.wd = value; }
        }

        public Airline()
        {
            this.destination = "Minsk";
            this.numOfFlight = 1;
            this.typeOfPlane = 'A';
            this.wd = weekDays.sun;
            Airline.tableSize++;
        }
        public Airline(string dest, int flight, char type, weekDays day)
        {
            this.destination = dest;
            this.numOfFlight = flight;
            this.typeOfPlane = type;
            this.wd = day;
            Airline.tableSize++;
        }


        public int CompareTo(object obj)
        {
            Airline airline = (Airline)obj;
            if (DAY > airline.DAY)
                return 1;
            if (DAY < airline.DAY)
                return -1;
            return 0;
        }
    }
}
