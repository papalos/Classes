using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            Building Office = new Building(6,30,0);
            Building House = new Building(16,50,750);

            
            Console.WriteLine(Office.getFloor()+" "+Office.getLodgers());
            Console.WriteLine(House.getFloor());

            return;
        }
    }
}
