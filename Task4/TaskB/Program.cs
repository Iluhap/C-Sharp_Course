using System;
using Watches;
using System.Collections.Generic;
/*
    Магазин часов. В сущностях (типах) хранится информация о часах, продающихся в магазине.
    Для часов необходимо хранить:
    — марку;
    — тип (кварцевые, механические);
    — цену;
    — количество;
    — реквизиты производителя.
    Для производителей необходимо хранить:
    — название;
    — страна.
    Вывести марки заданного типа часов.
    Вывести информацию о механических часах, цена на которые не превышает заданную.
    Вывести марки часов, изготовленных в заданной стране.
    Вывести производителей, общая сумма часов которых в магазине не превышает заданную.
 */
namespace TaskC
{
    class Program
    {
        static void Main(string[] args)
        {
            var watches = new List<Watch>
            {
                new Watch {
                    Amount = 12,
                    Brand = "Classic Fusion",
                    Price = 10000m,
                    Type = GearType.Mechanical,
                    Producer = new Manufacturer{
                        CountryName = "Switzerland",
                        Name = "Hublot"
                    }
                },
                new Watch {
                    Amount = 45,
                    Brand = "",
                    Price = 500m,
                    Type = GearType.Quartz,
                    Producer = new Manufacturer{
                        CountryName = "Japan",
                        Name = "Casio"
                    }
                },
                new Watch {
                    Amount = 200,
                    Brand = "Big Bang",
                    Price = 7200.50m,
                    Type = GearType.Quartz,
                    Producer = new Manufacturer{
                        CountryName = "Switzerland",
                        Name = "Hublot"
                    }
                },
                new Watch {
                    Amount = 9,
                    Brand = "Seiko Prospex 200M",
                    Price = 9500m,
                    Type = GearType.Mechanical,
                    Producer = new Manufacturer{
                        CountryName = "Japan",
                        Name = "Sekio"
                    }
                },
            };

            var shop = new WatchShop(watches);

            shop.GetManufacturers(123456m);
            shop.GetMechanicalByPrice(2345m);
            shop.GetWatchBrand("Japan");
            shop.GetWatchesByType(GearType.Quartz);
        }
    }
}
