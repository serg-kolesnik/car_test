using System;
using System.Collections.Generic;
using System.Linq;

namespace car_test
{
    internal class Car
    {
        private static readonly Random rng = new Random();

        int id;
        string mark;
        string color;

        public Car()
        {
            id = 0;
            mark = "Волга";
            color = "Черный";
        }

        public Car(int id, string mark, string color)
        {
            this.id = id;
            this.mark = mark;
            this.color = color;
        }

        public Car(int id, string mark)
        {
            this.id = id;
            this.mark = mark;
            this.color = "Черный";
        }

        public int Id { get => id; set => id = value; }
        public string Mark { get => mark; set => mark = value; }
        public string Color
        {
            get { return color; }
            set
            {
                if (value.ToLower() == "радужный")
                    throw new ArgumentException("Радужный цвет не поддерживается");
                color = value;
            }
        }
        public override string ToString()
        {
            return $"{id} {mark}, {color}";
        }

        public static int checkPrice(Car car)
        {
            if (car == null) return 0;

            int price = 0;
            string markLower = car.Mark?.ToLower() ?? "";

            if (new[] { "волга", "москвич", "жигули" }.Contains(markLower))
            {
                price += 100000;
            }
            else if (new[] { "мерседес", "бмв", "ауди" }.Contains(markLower))
            {
                price += 300000;
            }
            else if (new[] { "ламборгини", "феррари", "порше" }.Contains(markLower))
            {
                price += 1000000;
            }
            else
            {
                price += 50000;
            }
            return price;
        }

        public static bool testDrive(Car car)
        {
            if (car == null) return false;

            if (new[] { "бмв", "москвич", "жигули", "волга" }.Contains(car.Mark?.ToLower() ?? ""))
            {
                return rng.Next(0, 5) != 0;
            }
            return true;
        }
    }
}
