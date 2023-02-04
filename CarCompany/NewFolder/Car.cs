using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCompany
{
    public class Car
    {

        public long Id { get; set; } = new Random().NextInt64();
        public string? Model { get; set; }
        public double Price { get; set; }
        public bool IsUsed { get; set; }
        public long OwnerId { get; set; }



        public void ShowInformation()
        {
            //Console.WriteLine($"Owner Id: {OwnerId}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"   Price: {Price}");
            Console.WriteLine($"   Is Used: {IsUsed}");
            Console.WriteLine();
        }


    }
}

