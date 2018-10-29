using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    class Lab5
    {
        static void Main(string[] args)
        {
            Port port = new Port(4);
            try
            {
                port[0] = new Boat(44, "Ilya", 18, 0.45F);
                port[1] = new Sailboat(777, "Ilya", 28, 0.65F);

                //port[0] = new Boat(0, "Vitya", 20, 0.1);
                //port[1] = new Boat(11, "Vanya", 11, 1.1);
                //Console.WriteLine(port[5]);
                port[5] = new Boat(444, "Ilya", 4, 0.30F);
            }
            catch(PortException exception)
            {
                Console.WriteLine($"Error: {exception.Message} in {exception.ErrorClass}, actual: {exception.CountException}, expected: {exception.ExpectedCount}");
            }
            catch(VehicleException exception)
            {
                Console.WriteLine($"Error: {exception.Message} - {exception.CarringException}");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
            Console.WriteLine();

            try
            {
                port[0] = new Boat(44, "Ilya", 18, 0.45F);
                //port[1] = new Sailboat(777, "Ilya", 28, 0.65F);
                port[1] = new Boat(-99, "Valya", 99, 0.4);
                //Console.WriteLine(port[5]);
                port[5] = new Boat(444, "Ilya", 4, 0.30F);
            }
            catch(CustomException exception)
            {
                //VehicleException veh = (VehicleException)exception;
                //Console.WriteLine(veh.CarringException);

                object exc = exception as PortException;
                if(exc == null)
                {
                    exc = exception as VehicleException;
                    if (exc == null)
                        Console.WriteLine("Sorry");
                    else
                    {
                        VehicleException vehicleException = (VehicleException)exc;
                        Console.WriteLine($"Error: {vehicleException.Message} - {vehicleException.CarringException}");
                    }
                }
                else
                {
                    PortException portException = (PortException)exc;
                    Console.WriteLine($"Error: {portException.Message} in {portException.ErrorClass}, actual: {portException.CountException}, expected: {portException.ExpectedCount}");
                }
            }
            Console.WriteLine();

            try
            {
                Port port1 = new Port(2);
                port1[0] = new Boat(44, "Ilya", 18, 0.45F);
                port1[1] = new Boat(777, "Ilya", 28, 0.65F);
                //PortController.CalculateDisplacement(port1);
                throw new Exception("new standard exception");
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Hi");
            }

        }
    }
}
