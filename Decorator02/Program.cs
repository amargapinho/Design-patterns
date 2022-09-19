using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{

    public interface IFlightClass
    {
        void BookFlight();
    }

    public class EconomyClass : IFlightClass
    {
        public void BookFlight()
        {
            Console.WriteLine("Flight was booked.");
        }
    }

    public class BusinessClass : EconomyClass
    {
        public EconomyClass flight;

        public BusinessClass(EconomyClass flight)
        {
        }

        public new void BookFlight()
        {
            Console.WriteLine("Chosen Seat: " + ChooseSeats());
            base.BookFlight();
        }

        public int ChooseSeats()
        {
            Console.WriteLine("Seats can be chosen. Where would you like to sit?");
            int seat = Convert.ToInt32(Console.ReadLine());
            return seat;
        }
    }

    public class FirstClass : BusinessClass
    {
        public BusinessClass bCFlight;

        public FirstClass(BusinessClass flight) : base(flight)
        {
        }
        public new void BookFlight()
        {
            GetMenu();
            base.BookFlight();
        }

        public void GetMenu()
        {
            Console.WriteLine("Menu included.");
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            IFlightClass flight = new EconomyClass();
            Console.WriteLine("You selected 'Economy Class'.");
            flight.BookFlight();

            EconomyClass eflight = new EconomyClass();
            BusinessClass bCFlight = new BusinessClass(eflight);
            Console.WriteLine("You selected 'Business Class'.");
            bCFlight.BookFlight();
            bCFlight.ChooseSeats();

            FirstClass fCFlight = new FirstClass(bCFlight);
            Console.WriteLine("You selected 'First Class'.");
            fCFlight.BookFlight();
            fCFlight.ChooseSeats();
            fCFlight.GetMenu();

        }
    }
}