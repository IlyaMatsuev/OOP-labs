using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {

        private Program()
        {
            DESTINATION = "basic";
        }
        private Program(string dest)
        {
            DESTINATION = dest;
        }

        private string DESTINATION { get; set; }

        static void Main(string[] args)
        {
            string[] monthes = new string[] { "January", "Febriary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 4;
            var selectedStr = from m in monthes where m.Length == n select m;
            Console.WriteLine("n = " + n);
            foreach (string s in selectedStr)
                Console.WriteLine(s);
            selectedStr = from m in monthes where m == "June" || m == "July" || m == "August" select m;
            Console.WriteLine("Summer mon: ");
            foreach (string s in selectedStr)
                Console.WriteLine(s);
            selectedStr = monthes.Where(s => s.IndexOf("u") > -1).OrderBy(s => s);
            Console.WriteLine("Mon with 'u' oredred by alphabet: ");
            foreach (string s in selectedStr)
                Console.WriteLine(s);
            int count = (selectedStr.Where(s => s.Length >= 4)).Count();
            Console.WriteLine("Count: " + count);

            Console.WriteLine("=========================================================");

            var airlaines = new List<Airline>();
            airlaines.AddRange(new Airline[] {
                new Airline(),
                new Airline("Minsk", 22, 'A', Airline.weekDays.fri),
                new Airline("Minsk", 88, 'A', Airline.weekDays.mon),
                new Airline("Vitebsk", 2, 'B', Airline.weekDays.thir),
                new Airline("Mogilev", 1, 'A', Airline.weekDays.fri),
                new Airline("Mogilev", 422, 'C', Airline.weekDays.wen)
            });
            string dest = "Minsk";
            var flightsByDest = from a in airlaines where a.DESTINATION == dest select a;
            foreach (var flight in flightsByDest)
                flight.ShowDetail();

            Console.WriteLine("=========================================================");

            Airline.weekDays day = Airline.weekDays.mon;
            var flightsByDay = from a in airlaines where a.DAY == day select a;
            foreach (var flight in flightsByDay)
                flight.ShowDetail();

            Console.WriteLine("=========================================================");

            Airline morningFlight = airlaines.Where(s => s.DAY == Airline.weekDays.mon).Min();
            morningFlight.ShowDetail();

            Console.WriteLine("=========================================================");

            Airline eveningFlight = airlaines.Where(s => s.DAY == Airline.weekDays.wen || s.DAY == Airline.weekDays.fri).Max();
            eveningFlight.ShowDetail();

            Console.WriteLine("=========================================================");

            IEnumerable<IGrouping<Airline.weekDays, Airline>> groupByDay = from flight in airlaines orderby flight.DAY ascending group flight by flight.DAY;
            foreach(IGrouping<Airline.weekDays, Airline> fl in groupByDay)
            {
                Console.WriteLine(fl.Key);
                foreach (Airline airline in fl)
                    airline.ShowDetail();
            }

            Console.WriteLine("=========================================================");

            Airline[] customQuery = airlaines.Where(a => a.DAY != Airline.weekDays.mon && a.NUMOFFLIGHT < 100).OrderByDescending(a => a.DESTINATION).Skip(2).Reverse().ToArray();

            foreach (Airline cq in customQuery)
                cq.ShowDetail();

            Console.WriteLine("=========================================================");

            var mainlist = new Program[]
            {
                new Program("Gomel"),
                new Program(),
                new Program("Mogilev"),
                new Program("Minsk")
            };

            var result = from resair in airlaines
                         join resmain in mainlist on resair.DESTINATION equals resmain.DESTINATION
                         select new
                         {
                             Name = resair.NUMOFFLIGHT,
                             Type = resmain.DESTINATION
                         };
            foreach (var res in result)
                Console.WriteLine(res.Name + "\t" + res.Type);

            Console.WriteLine("=========================================================");

            var result1 = airlaines.Join(mainlist, p => p.DESTINATION, t => t.DESTINATION, (p, t) => new { Name = p.TYPEOFPLANE, Something = t.DESTINATION, Day = p.DAY });
            foreach (var res in result1)
                Console.WriteLine(res.Name + "\t" + res.Something + "\t"  +res.Day);
        }
    }
}
