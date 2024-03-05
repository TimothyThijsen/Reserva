using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicClasses
{
    public class Room
    {
        int id, quantity;
        string name;
        decimal price;
        Schedule schedule;

        public Room(int id, int quantity, string name, decimal price, Schedule schedule)
        {
            this.id = id;
            this.quantity = quantity;
            this.name = name;
            this.price = price;
            this.schedule = schedule;
        }
    }
}
