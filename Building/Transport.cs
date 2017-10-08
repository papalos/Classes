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
        protected Driver driver;
        protected int gas;           //Запас топлива в литрах или в кг (для повозки)
        protected int maxDistance;   //Запас хода в км
        protected char document;     //Категория прав 
        protected int health;        //Износ  в единицах здоровья

        public Transport(int gas, int maxDistance, char document, int health)
        {
            this.gas = gas;
            this.maxDistance = maxDistance;
            this.document = document;
            this.health = health;
        }

        public int getGas()
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
        abstract public void refuel(int volume);

        /// <summary>
        /// Отдых для востановления запаса хода
        /// </summary>
        /// <param name="time">время отдыха в минутах</param>
        abstract public void rest(int time);
    }

    class Wagon : Transport
    {
        public Wagon(Driver driver) : base(4,10,'N',5) { this.driver = driver; }

        public override void move(int range)
        {
            //Дописать реализацию чтобы при движении иссекал запас хода усталость запускаем метод отдых
            //движение расходовало еду запускался метод кормление
            //водитель оказывает прямое действие на износ
        }

    }
}
