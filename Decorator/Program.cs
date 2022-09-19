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
        public virtual void BookFlight()
        {
            Console.WriteLine("Flight was booked.");
        }
    }

    public class BusinessClass: EconomyClass
    {
        public EconomyClass flight;

        public BusinessClass()
        {
            this.flight = flight;
        }

        public override void BookFlight()
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

        public FirstClass()
        {
        }
        public override void BookFlight()
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

            flight = new BusinessClass();
            Console.WriteLine("You selected 'Business Class'.");
            flight.BookFlight();

            flight = new FirstClass();
            Console.WriteLine("You selected 'First Class'.");
            flight.BookFlight();

        }
    }
}