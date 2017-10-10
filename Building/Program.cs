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
            /********************* Задание 2 ***************************/
            /*Создаем объекты Офиса и Жилого Дома*/
            Building Office = new Building(6,30,0);
            Building House = new Building(16,50,750);

            /*Выводим характеристики Построенных зданий*/
            Console.WriteLine("Количество Этажей в " + Office.kindOfBilding() + ": " + Office.getFloor()+ ", количество жильцов: " + Office.getLodgers());
            Console.WriteLine("Количество Этажей в " + House.kindOfBilding() + ": " + House.getFloor());
            Console.WriteLine("\n\n\n");

            //Console.WriteLine("{0,10:d};{1,10:d};{2,10:d}",1,100,1000,10000); //Test

            /******************** Задание 3 *******************/

            /*Создаем объекты 4 типов*/
            Wagon Cart = new Wagon(Driver.FOOL);
            Car Auto = new Car(Driver.NORMAL);
            Plane Aircraft = new Plane(Driver.PROFESSIONAL);
            MotorBoat Craft = new MotorBoat(Driver.VETERAN);

            /* Статический метод выводящий характеристики ТС до движения */
            TableWrite.Write(Cart, Auto, Aircraft, Craft);

            /* Статический метод выводящий характеристики ТС после движения */
            TableWrite.Write(Cart, 4, Auto, 50, Aircraft, 125, Craft, 15);

            return;
        }
    }
}
