using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    enum Driver { FOOL = 0, NORMAL, VETERAN, PROFESSIONAL};

    abstract class Transport
    {
        protected Driver driver;      //Опыт водителя
        protected double gas;         //Запас топлива в литрах или в кг (для повозки)
        protected int maxDistance;
        protected int distance;       //Запас хода в км
        protected char document;      //Категория прав 
        protected int health;         //Износ  в единицах здоровья

        public Transport(double gas, int maxDistance, char document, int health)
        {
            this.gas = gas;
            this.distance = this.maxDistance = maxDistance;
            this.document = document;
            this.health = health;
        }

        public double getGas()
        {
            return gas;
        }

        public int getDistance()
        {
            return maxDistance;
        }

        public char getDocument()
        {
            return document;
        }

        public int getHealth()
        {
            return health;
        }
        
        /// <summary>
        /// Описывает движение транспорта
        /// </summary>
        /// <param name="range">дистанция передвижения в км.</param>
        abstract public void move(int range);

        /// <summary>
        /// Заправка или кормежка
        /// </summary>
        /// <param name="volume">объем топлива в литрах или в кг (для повозки)</param>
        abstract public void refuel(double volume);

        /// <summary>
        /// Отдых для востановления запаса хода
        /// </summary>
        /// <param name="time">время отдыха в минутах</param>
        abstract public void rest(int time);
    }

    class Wagon : Transport
    {
        bool flag = true;    //прервать движение если один из параметров достиг минимума

        /// <summary>
        /// Создаем Лошадь 
        /// </summary>
        /// <param name="driver"></param>
        public Wagon(Driver driver) : base(4d,10,'N',100) { this.driver = driver; }

        /// <summary>
        /// Сообщение о снижение характеристики ниже критического значения
        /// </summary>
        private string writeMessage()
        {
            string msg="";
            if (gas < 0.25)
            {
                msg += " Лошадь не может двигаться, она голодна. Покорми ее!";
                flag = false;
            }
            else
            {
                if (maxDistance < 1)
                {
                    msg += " Лошадь не может больше идти, она устала. Ей нужен отдых!";
                    flag = false;
                }
                else
                {
                    if (health <= 0)
                    {
                        msg += " Лошадь - старая, она скоро сдохнет!";
                        flag = false;
                    }
                }
            }
            return msg;
        }

        /// <summary>
        /// Двигает лошадь и расходует ресурсы
        /// </summary>
        /// <param name="range">Дистанция перемещения в киллометрах</param>
        public override void move(int range)
        {
            for ( ; range>0; range--)
            {
                Console.WriteLine(writeMessage());
                if (flag == false) { return; }
                distance--;
                gas -= 0.25;
                if(driver == Driver.FOOL)
                {
                    health -= 5;
                }
                else
                {
                    health -= 2;
                }
            }
        }

        public override void refuel(double volume)
        {
            gas += volume;
        }
        
        public override void rest(int time)
        {
            distance += time / 5;
            if (distance > maxDistance)
            {
                distance = maxDistance; 
            }
        }

    }

    class Car : Transport
    {
        bool flag = true;    //прервать движение если один из параметров достиг минимума

        /// <summary>
        /// Создаем Лошадь 
        /// </summary>
        /// <param name="driver"></param>
        public Car(Driver driver) : base(100d, 200,'B',1000) { this.driver = driver; }

        /// <summary>
        /// Сообщение о снижение характеристики ниже критического значения
        /// </summary>
        private string writeMessage()
        {
            string msg = "";
            if (gas < 0.25)
            {
                msg += " Автомобиль не может двигаться, кончился бензин. Заправь его!";
                flag = false;
            }
            else
            {
                if (maxDistance < 1)
                {
                    msg += " Автомобиль не может больше ехать, двигатель перегрелся. Агрегату необходим отдых!";
                    flag = false;
                }
                else
                {
                    if (health <= 0)
                    {
                        msg += " Из-за старости агрегатов или неумелого обращения автомобиль пришел в негодность!";
                        flag = false;
                    }
                }
            }
            return msg;
        }

        /// <summary>
        /// Двигает автомобиль и расходует ресурсы
        /// </summary>
        /// <param name="range">Дистанция перемещения в киллометрах</param>
        public override void move(int range)
        {
            for (; range > 0; range--)
            {
                Console.WriteLine(writeMessage());
                if (flag == false) { return; }
                distance--;
                gas -= 0.5;
                if (driver == Driver.FOOL)
                {
                    health = 0;
                }
                else
                {
                    if (driver == Driver.NORMAL)
                    {
                        health -= 25;
                    }
                    else
                    {
                        health -= 5;
                    }
                }
            }
        }

        public override void refuel(double volume)
        {
            gas += volume;
        }

        public override void rest(int time)
        {
            if (time > 20)
            {
                distance = maxDistance;
                Console.WriteLine("Все нормально, можем ехать!");
            }
            else
            {
                Console.WriteLine("Недостаточное время для охлаждения!");
            }
        }

    }

    class Plane : Transport
    {
        bool flag = true;    //прервать движение если один из параметров достиг минимума

        /// <summary>
        /// Создаем Самолет
        /// </summary>
        /// <param name="driver"></param>
        public Plane (Driver driver) : base(50d,1000,'P',10000) { this.driver = driver; }

        /// <summary>
        /// Сообщение о снижение характеристики ниже критического значения
        /// </summary>
        private string writeMessage()
        {
            string msg = "";
            if (gas < 0.25)
            {
                msg += " Топливо на нуле! Мы не дотянем до дозаправки! Мы падаем!";
                health = 0;
                flag = false;
            }
            else
            {
                if (maxDistance < 1)
                {
                    msg += " Требуется экстренная посадка! Необходимо произвести обслуживание систем!";
                    health -= 100;
                    flag = false;
                }
                else
                {
                    if (health <= 0)
                    {
                        msg += " Отказ всех систем! Мы падаем!";
                        flag = false;
                    }
                }
            }
            return msg;
        }

        /// <summary>
        /// Двигает самолет и расходует ресурсы
        /// </summary>
        /// <param name="range">Дистанция перемещения в киллометрах</param>
        public override void move(int range)
        {
            for (; range > 0; range--)
            {
                Console.WriteLine(writeMessage());
                if (flag == false) { return; }                
                gas -= 0.25;
                if (driver < Driver.VETERAN)
                {
                    health = 0;
                }
                else
                {
                    if (driver == Driver.VETERAN)
                    {
                        health -= 20;
                        distance--;
                    }
                    if (driver == Driver.PROFESSIONAL)
                    {
                        health -= 10;
                        distance-=2;
                    }

                }
            }
        }

        public override void refuel(double volume)
        {
            gas += volume;
        }

        public override void rest(int time)
        {
            
            if (time>=60)
            {
                distance = maxDistance;
                Console.WriteLine("Диагностика систем прошла успешно. Можем лететь");
            }
            else
            {
                Console.WriteLine("Недостаточно времени на диагностику систем");
            }
        }
    }









}
