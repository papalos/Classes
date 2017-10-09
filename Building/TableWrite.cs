using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    static class TableWrite
    {
        static public void Write(Wagon Wagon, Car Car, Plane Plane, MotorBoat MotorBoat)
        {
            int wdist = Wagon.move(4);           // Повозка двигается  4 км.
            int cdist = Car.move(123);           // Машина двигается 123 км.
            int pdist = Plane.move(300);         // Самолет летит 300 км.
            int mbdist = MotorBoat.move(50);     // Катер двигается 50 км.

            Console.WriteLine("{0} | {1} | {2} | {3} | {4}", "Транспорт", "Пройденное расстояние", "Запас топлива", "Оставшийся ресурс", "Запас хода");
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:d} | {3,17:d} | {4,10:d}", "Повозка", wdist, Wagon.getGas(), Wagon.getHealth(), Wagon.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:d} | {3,17:d} | {4,10:d}", "Машина", cdist, Car.getGas(), Car.getHealth(), Car.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:d} | {3,17:d} | {4,10:d}", "Самолет", pdist, Plane.getGas(), Plane.getHealth(), Plane.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:d} | {3,17:d} | {4,10:d}", "Катер", mbdist, MotorBoat.getGas(), MotorBoat.getHealth(), MotorBoat.getDistance());
        }
    }
}
