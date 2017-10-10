using System;

namespace Building
{
    /* Возможные уровни навыка вождения */
    enum Driver { FOOL = 0, NORMAL, VETERAN, PROFESSIONAL};


    /********************************************* Абстрактный класс Транспорт, родительский для остальных *******************************************/

    abstract class Transport
    {
        protected Driver driver;                    //Опыт водителя
        protected double gas;                       //Запас топлива в литрах или в кг (для повозки)
        protected int maxDistance;                  //Максимальное расстояние которое может пройти транспорт до усталости
        protected int distance;                     //Запас хода в км
        protected char document;                    //Категория прав 
        protected int health;                       //Износ  в единицах здоровья

        /* Сообщения для метода writeMessage() информирующего о достижении предельных значений свои в каждом дочернем классе */
        protected string lowGas;                    
        protected string lowDistance;
        protected string lowHealth;

        protected bool flag = true;    // прервать движение если один из параметров достиг минимума, определяет срабатывания условия по смене флага
        
        
        /// <summary>
        /// Конструктор базового класса
        /// </summary>
        /// Исходные значения
        /// <param name="gas">Количество топлива</param>
        /// <param name="maxDistance">Максимально возможное расстояние до тех обслуживания</param>
        /// <param name="document"> Категория водительских прав </param>
        /// <param name="health"> Единицы здоровья убывающие в соответствии с навыком воздения и пройденным расстоянием </param>
        public Transport(double gas, int maxDistance, char document, int health)
        {
            this.gas = gas;
            this.distance = this.maxDistance = maxDistance;
            this.document = document;
            this.health = health;
        }


        /* ------------------------ Геттеры для полей класса ------------------------ */
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
        /* -------------------------------------------------------------------------- */


        /// <summary>
        /// Метод сообщающий о снижение характеристики ниже критического значения
        /// </summary>
        protected string writeMessage()
        {
            string msg = "";
            if (gas < 0.25)
            {
                msg += lowGas;
                flag = false;
            }
            else
            {
                if (distance < 1)
                {
                    msg += lowDistance;
                    flag = false;
                }
                else
                {
                    if (health <= 0)
                    {
                        msg += lowHealth;
                        flag = false;
                    }
                }
            }
            return msg;
        }

        /// <summary>
        /// Описывает движение транспорта (переопределяемый метод)
        /// </summary>
        /// <param name="range">дистанция передвижения в км.</param>
        abstract public int move(int range);

        /// <summary>
        /// Заправка или кормежка  (переопределяемый метод)
        /// </summary>
        /// <param name="volume">объем топлива в литрах или в кг (для повозки)</param>
        abstract public void refuel(double volume);

        /// <summary>
        /// Отдых для востановления запаса хода (переопределяемый метод)
        /// </summary>
        /// <param name="time">время отдыха в минутах</param>
        abstract public void rest(int time);
    }


    /************************************************************* Повозка **************************************************************************/

    class Wagon : Transport             // Наследуемся от Transport
    {
        /// <summary>
        /// Создаем Лошадь 
        /// Характеристики создаваемого ТС заданы жестко в вызываемом конструкторе безового класса
        /// </summary>
        /// <param name="driver">Тип навыка вождения управляющего данным ТС</param>
        public Wagon(Driver driver) : base(4d,10,'N',100)
        {
            this.driver = driver;
            /* Определяем поля необходимые для вывода критических сообщений */
            this.lowGas = " Лошадь не может двигаться, она голодна. Покорми ее!";
            this.lowDistance = " Лошадь не может больше идти, она устала. Ей нужен отдых!";
            this.lowHealth = " Лошадь - старая, она скоро сдохнет!";
        }             

        /// <summary>
        /// Двигает лошадь и расходует ресурсы
        /// </summary>
        /// <param name="range">Дистанция перемещения в киллометрах</param>
        public override int move(int range)
        {
            int start = range;                // Сохнаряем изначально заданное количества движения, range изменится в соответсвии с пройденным до поломки расстоянием
            string msg = "";                  // Переменна для информации полученной из writeMessage() при условии поломок

            for (; range > 0; range--)
            {
                msg = writeMessage();        // Проверяем на поломки методом  writeMessage(), сохраняя сведения о ник в переменной msg и меняя при их возникновении flag см. реализацию метода

                if (flag == false)                     // Если флаг сменен  на false, значит возникла поломка
                {
                    Console.WriteLine(msg);            // Выводим сообщение о ней
                    break;                             // И выходим из цикла
                }
                                                       // Если поломок не возникает уменьшаем характеристики за каждый пройденный километр в соответствии с условиями
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
            return start-range;               // По завершению работы метода возвращаем количество километров которое удалось пройти
        }

        /// <summary>
        /// Заправка топливом ТС
        /// </summary>
        /// <param name="volume">Количество топлива или еды</param>
        public override void refuel(double volume)
        {
            gas += volume;
        }
        
        /// <summary>
        /// Лошадь за каждые 5 минут отдыха сможет пройти 1 км., но не более максимального
        /// </summary>
        /// <param name="time"> Отдых в минутах</param>
        public override void rest(int time)
        {
            distance += time / 5;
            if (distance > maxDistance)
            {
                distance = maxDistance; 
            }
        }

    }

    /* !!!!!!!!!!!!!!!!!!!!!! Остальные классы реализованы соответственно классу Wagon !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */

    /************************************************************* Машина ***************************************************************************/

    class Car : Transport
    {
        /// <summary>
        /// Создаем Машину
        /// </summary>
        /// <param name="driver">Сажаем водителя</param>
        public Car(Driver driver) : base(100d, 200,'B',1000)
        {
            this.driver = driver;
            this.lowGas = " Автомобиль не может двигаться, кончился бензин. Заправь его!";
            this.lowDistance = " Автомобиль не может больше ехать, двигатель перегрелся. Агрегату необходим отдых!";
            this.lowHealth = " Из-за старости агрегатов или неумелого обращения автомобиль пришел в негодность!";
        }        

        /// <summary>
        /// Двигает автомобиль и расходует ресурсы
        /// </summary>
        /// <param name="range">Дистанция перемещения в киллометрах</param>
        public override int move(int range)
        {
            int start = range;
            string msg = "";
            for (; range > 0; range--)
            {
                msg = writeMessage();
                
                if (flag == false)
                {
                    Console.WriteLine(msg);
                    break;
                }

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
                        health -= 7;
                    }
                    else
                    {
                        health -= 3;
                    }
                }
            }
            return start-range;
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



    /************************************************************ Самолет ****************************************************************************/

    class Plane : Transport
    {
        /// <summary>
        /// Создаем Самолет
        /// </summary>
        /// <param name="driver"></param>
        public Plane (Driver driver) : base(50d,1000,'P',10000)
        {
            this.driver = driver;
            this.lowGas = " Топливо на нуле! Мы не дотянем до дозаправки! Мы падаем!";
            this.lowDistance = " Требуется экстренная посадка! Необходимо произвести обслуживание систем!";
            this.lowHealth = " Отказ всех систем! Мы падаем!";
        }

        /// <summary>
        /// Двигает самолет и расходует ресурсы
        /// </summary>
        /// <param name="range">Дистанция перемещения в киллометрах</param>
        public override int move(int range)
        {
            int start = range;
            string msg = "";
            for (; range > 0; range--)
            {
                msg = writeMessage();

                if (flag == false)
                {
                    Console.WriteLine(msg);
                    break;
                }
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
            return start-range;
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



    /*************************************************************** Катер **************************************************************************/
    class MotorBoat : Transport
    {
        /// <summary>
        /// Создаем Катер
        /// </summary>
        /// <param name="driver"></param>
        public MotorBoat (Driver driver) : base(20d, 100, 'M', 1000)
        {
            this.driver = driver;
            this.lowGas = " Топливо на нуле! Заправься если достиг порта!";
            this.lowDistance = " Мотор перегрелся! Включить охлаждение забортной водой!";
            this.lowHealth = " Отказ двигателя! Катер на списание!";
        }

        /// <summary>
        /// Двигает катер и расходует ресурсы
        /// </summary>
        /// <param name="range">Дистанция перемещения в киллометрах</param>
        public override int move(int range)
        {
            int start = range;
            string msg = "";
            for (; range > 0; range--)
            {
                msg = writeMessage();

                if (flag == false)
                {
                    Console.WriteLine(msg);
                    break;
                }
                gas -= 1;
                if (driver != Driver.FOOL)
                {
                    health -= 20;
                    distance--;
                }
                else
                {
                    health = 0;
                }
            }
            return start-range;
        }

        public override void refuel(double volume)
        {
            gas += volume;
        }

        public override void rest(int time)
        {

            if (time >= 30)
            {
                distance = maxDistance;
                Console.WriteLine("Система охлаждена. Можем плыть");
            }
            else
            {
                Console.WriteLine("Недостаточно времени для охлаждения агрегатов");
            }
        }
    }

}
