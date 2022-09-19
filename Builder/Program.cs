using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class House
    {
        public string Structure { get; set; }

        public int Rooms { get; set; }

        public bool Garage { get; set; }

        public string Interior { get; set; }

        public string HousePlan()
        {
            return "Type of Structure: " + Structure + ", Type of Interior: " + Interior +
                ", Number of Rooms: " + Rooms + ", Does it have a garage? " + (Garage ? "yes" : "no"); 
        }
    }

    public abstract class HouseBuilder
    {
        protected House house;

        public void BuildHouse()
        {
            house = new House();
        }

        public House GetHouse()
        {
            return house;
        }

        public abstract void SetStructure();
        public abstract void SetRooms();
        public abstract void SetGarage();
        public abstract void SetInterior();
    }

    public class CottageBuilder : HouseBuilder
    {
        public override void SetStructure()
        {
            GetHouse().Structure = "Single-family";
        }

        public override void SetRooms()
        {
            GetHouse().Rooms = 4;
        }

        public override void SetGarage()
        {
            GetHouse().Garage = true;
        }

        public override void SetInterior()
        {
            GetHouse().Interior = "Traditional";
        }
    }

    public class StudioBuilder : HouseBuilder
    {
        public override void SetStructure()
        {
            GetHouse().Structure = "Apartment";
        }

        public override void SetRooms()
        {
            GetHouse().Rooms = 1;
        }

        public override void SetGarage()
        {
            GetHouse().Garage = false;
        }

        public override void SetInterior()
        {
            GetHouse().Interior = "Contemporary";
        }
    }

    public class CivilEngineer
    {
        public House BuildHouse(HouseBuilder housebuilder)
        {
            housebuilder.BuildHouse();

            housebuilder.SetStructure();
            housebuilder.SetRooms();
            housebuilder.SetGarage();
            housebuilder.SetInterior();

            return housebuilder.GetHouse();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            House house;
            CivilEngineer civilEngineer = new CivilEngineer();

            CottageBuilder cottage = new CottageBuilder();
            house = civilEngineer.BuildHouse(cottage);
            Console.WriteLine(house.HousePlan());

            StudioBuilder apartment = new StudioBuilder();
            house = civilEngineer.BuildHouse(apartment);
            Console.WriteLine(house.HousePlan());
           
        }
    }
}
