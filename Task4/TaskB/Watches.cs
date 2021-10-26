using System;

using System.Collections.Generic;

namespace Watches
{
    class WatchShop
    {
        private List<Watch> watches = new List<Watch>();

        public WatchShop(List<Watch> watches)
        {
            this.watches = watches;
        }

        public void AddWatch(Watch watch) => watches.Add(watch);

        public void GetWatchesByType(GearType type)
        {
            foreach (var item in watches)
            {
                if (item.Type == type)
                    Console.WriteLine($"{item}\n");
            }
        }

        public void GetMechanicalByPrice(decimal required_price)
        {
            foreach (var item in watches)
            {
                if (item.Type == GearType.Mechanical && item.Price > required_price)
                {
                    Console.WriteLine($"{item}\n");
                }
            }
        }

        public void GetWatchBrand(string country)
        {
            foreach (var item in watches)
            {
                if (item.Producer.CountryName == country)
                {
                    Console.WriteLine($"{item.Brand}\t");
                }
            }
        }

        public void GetManufacturers(decimal price_upper_bound)
        {
            var producers = new Dictionary<Manufacturer, decimal>();

            foreach (var item in watches)
            {
                if (!producers.ContainsKey(item.Producer))
                    producers[item.Producer] = item.Price;
                else
                    producers[item.Producer] += item.Price;
            }

            foreach (var key in producers.Keys)
            {
                if (producers[key] <= price_upper_bound)
                {
                    Console.WriteLine($"{key}");
                }
            }
        }
    }

    enum GearType { Mechanical, Quartz }

    class Watch
    {
        public string Brand { get; set; }
        public GearType Type { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Manufacturer Producer { get; set; }

        public override string ToString()
        {
            return $"Brand: {Brand}\n" +
                $"GearType: {Type}\n" +
                $"Price: {Price}\n" +
                $"Amount: {Amount}\n" +
                $"{Producer}";
        }
    }

    struct Manufacturer
    {
        public string Name { get; set; }
        public string CountryName { get; set; }

        public override string ToString()
        {
            return $"Manufacturer:\n\tName: {Name}\t Country: {CountryName}";
        }
    }
}