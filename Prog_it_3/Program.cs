using System;
using System.Collections.Generic;
using System.Linq;

namespace Prog_it_3
{
    // Базовый класс "Самолет"
    class Aircraft
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int SeatingCapacity { get; set; }
        public double PayloadCapacity { get; set; }
        public double FuelConsumption { get; set; }

        public Aircraft(string manufacturer, string model, int seatingCapacity, double payloadCapacity, double fuelConsumption)
        {
            Manufacturer = manufacturer;
            Model = model;
            SeatingCapacity = seatingCapacity;
            PayloadCapacity = payloadCapacity;
            FuelConsumption = fuelConsumption;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model}";
        }
    }

    // Класс "Пассажирский самолет", наследуется от базового класса "Самолет"
    class PassengerAircraft : Aircraft
    {
        public PassengerAircraft(string manufacturer, string model, int seatingCapacity, double payloadCapacity, double fuelConsumption)
            : base(manufacturer, model, seatingCapacity, payloadCapacity, fuelConsumption)
        {
        }
    }

    // Класс "Грузовой самолет", наследуется от базового класса "Самолет"
    class CargoAircraft : Aircraft
    {
        public CargoAircraft(string manufacturer, string model, int seatingCapacity, double payloadCapacity, double fuelConsumption)
            : base(manufacturer, model, seatingCapacity, payloadCapacity, fuelConsumption)
        {
        }
    }

    // Класс "Авиакомпания"
    class Airline
    {
        public List<Aircraft> Aircrafts { get; set; }

        public Airline()
        {
            Aircrafts = new List<Aircraft>();
        }

        public void AddAircraft(Aircraft aircraft)
        {
            Aircrafts.Add(aircraft);
        }

        public int CalculateTotalSeatingCapacity()
        {
            return Aircrafts.Sum(a => a.SeatingCapacity);
        }

        public double CalculateTotalPayloadCapacity()
        {
            return Aircrafts.Sum(a => a.PayloadCapacity);
        }

        public List<Aircraft> SortAircraftsByRange()
        {
            return Aircrafts.OrderBy(a => a.FuelConsumption).ToList();
        }

        public List<Aircraft> FindAircraftByFuelConsumptionRange(double minFuelConsumption, double maxFuelConsumption)
        {
            return Aircrafts.Where(a => a.FuelConsumption >= minFuelConsumption && a.FuelConsumption <= maxFuelConsumption).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание авиакомпании
            Airline airline = new Airline();

            // Добавление самолетов в авиакомпанию
            airline.AddAircraft(new PassengerAircraft("Boeing", "747", 416, 396000, 1.93));
            airline.AddAircraft(new PassengerAircraft("Airbus", "A380", 853, 560000, 2.92));
            airline.AddAircraft(new CargoAircraft("Antonov", "An-225", 6, 250000, 1.82));
            airline.AddAircraft(new CargoAircraft("Boeing", "747-400F", 416, 295800, 2.33));

            // Расчет общей вместимости и грузоподъемности
            int totalSeatingCapacity = airline.CalculateTotalSeatingCapacity();
            double totalPayloadCapacity = airline.CalculateTotalPayloadCapacity();

            Console.WriteLine($"Общая вместимость: {totalSeatingCapacity}");
            Console.WriteLine($"Общая грузоподъемность: {totalPayloadCapacity}");

            // Сортировка самолетов по дальности полета
            List<Aircraft> sortedAircrafts = airline.SortAircraftsByRange();
            Console.WriteLine("Самолеты, отсортированные по дальности полета:");
            foreach (Aircraft aircraft in sortedAircrafts)
            {
                Console.WriteLine(aircraft);
            }

            // Поиск самолетов в заданном диапазоне потребления горючего
            double minFuelConsumption = 1.5;
            double maxFuelConsumption = 2.5;
            List<Aircraft> aircraftsInRange = airline.FindAircraftByFuelConsumptionRange(minFuelConsumption, maxFuelConsumption);
            Console.WriteLine($"Самолеты с потреблением горючего от {minFuelConsumption} до {maxFuelConsumption}:");
            foreach (Aircraft aircraft in aircraftsInRange)
            {
                Console.WriteLine(aircraft);
            }
        }
    }
}
