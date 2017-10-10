using System;

namespace Building
{
    static class TableWrite
    {
        /// <summary>
        /// Принимает 4 объекта разных типов и их дальности передвижения,
        /// и выводит в виде таблицы характеристики объектров до движения
        /// </summary>
        /// <param name="Wagon">Повозка</param>
        /// <param name="Car">Машина</param>
        /// <param name="Plane">Самолет</param>
        /// <param name="MotorBoat">Катер</param>
        static public void Write(Wagon Wagon, Car Car, Plane Plane, MotorBoat MotorBoat)
        {


            int wdist = 0;
            int cdist = 0;
            int pdist = 0;
            int mbdist = 0;

            Console.WriteLine("Характеристики ТС до начала передвижения \n");

            Console.WriteLine("{0} | {1} | {2} | {3} | {4}", "Транспорт", "Пройденное расстояние", "Запас топлива", "Оставшийся ресурс", "Запас хода");
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Повозка", wdist, Wagon.getGas(), Wagon.getHealth(), Wagon.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Машина", cdist, Car.getGas(), Car.getHealth(), Car.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Самолет", pdist, Plane.getGas(), Plane.getHealth(), Plane.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Катер", mbdist, MotorBoat.getGas(), MotorBoat.getHealth(), MotorBoat.getDistance());
            
        }


        /// <summary>
        /// Принимает 4 объекта разных типов и их дальности передвижения,
        /// и выводит в виде таблицы характеристики объектров после движения
        /// </summary>
        /// <param name="Wagon">Повозка</param>
        /// <param name="wmove">расстояние передвижения Повозки</param>
        /// <param name="Car">Машина</param>
        /// <param name="cmove">расстояние передвижения Машины</param>
        /// <param name="Plane">Самолет</param>
        /// <param name="pmove">расстояние передвижения Самолета</param>
        /// <param name="MotorBoat">Катер</param>
        /// <param name="mbmove">расстояние передвижения Катера</param>
        static public void Write(Wagon Wagon, int wmove, Car Car, int cmove, Plane Plane, int pmove, MotorBoat MotorBoat, int mbmove)
        {
            Console.WriteLine("\n\n Характеристики ТС после передвижения \n");
            
            int wdist = Wagon.move(wmove);
            int cdist = Car.move(cmove);
            int pdist = Plane.move(pmove);
            int mbdist = MotorBoat.move(mbmove);

            Console.WriteLine("{0} | {1} | {2} | {3} | {4}", "Транспорт", "Пройденное расстояние", "Запас топлива", "Оставшийся ресурс", "Запас хода");
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Повозка", wdist, Wagon.getGas(), Wagon.getHealth(), Wagon.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Машина", cdist, Car.getGas(), Car.getHealth(), Car.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Самолет", pdist, Plane.getGas(), Plane.getHealth(), Plane.getDistance());
            Console.WriteLine("{0,9} | {1,21:d} | {2,13:f} | {3,17:d} | {4,10:d}", "Катер", mbdist, MotorBoat.getGas(), MotorBoat.getHealth(), MotorBoat.getDistance());
        }
    }
}
