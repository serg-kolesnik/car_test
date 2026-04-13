using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_test
{
    internal class Car
    {
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
        }

        public int Id { get => id; set => id = value; }
        public string Mark { get => mark; set => mark = value; }
        public string Color
        {
            get { return color; }
            set
            {
                if (value.ToLower() == "радужный") throw new Exception("Радужный цвет не поддерживается");
                color = value;
            }
        }
        public override string ToString()
        {
            return $"{id} {mark}, {color}";
        }

        public static int checkPrice(Car car)
        {
            int price = 0;
            if (new[] { "волга", "москвич", "жигули" }.Contains(car.Mark.ToLower()))
            {
                price += 100000;
            }
            else if (new[] { "мерседес", "бмв", "ауди" }.Contains(car.Mark.ToLower()))
            {
                price += 300000;
            }
            else if (new[] { "ламборгини", "феррари", "порше" }.Contains(car.Mark.ToLower()))
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
            bool success = true;
            if (new[] { "бмв", "москвич", "жигули", "волга" }.Contains(car.Mark.ToLower()))
            {
                success = Convert.ToBoolean(new Random().Next(0, 5));
            }
            return success;
        }
    }
}
