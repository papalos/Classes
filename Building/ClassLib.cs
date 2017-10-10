using System;

namespace Building
{
    /* Класс для задания зданий трех типов Офисов, Жилиых Домов и Складских Помещений */
    class Building
    {
        private uint floor;          //Количество этажей здания
        private double square;       //Общая площадь здания
        private uint lodgers;        //Количество жильцов

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="floor">Количество этажей здания</param>
        /// <param name="square">Общая площадь здания</param>
        /// <param name="lodgers">Количество жильцов</param>
        public Building(uint floor, double square, uint lodgers)
        {
            /* Проверяем допустимость значений */
            if (floor < 1)
            {
                throw new Exception("Отсутствие этажей у здания");
            }
            else
            {
                this.floor = floor;
            }

            if (square <= 0)
            {
                throw new Exception("Отрицательная площадь");
            }
            else
            {
                this.square = square;
            }

            if (lodgers < 0)
            {
                throw new Exception("Отрицательное количество жильцов");
            }
            else
            {
                this.lodgers = lodgers;
            }
            
        }


        /* -------------- Геттеры для этажей, площади и количества жильцов ---------- */
        public uint getFloor()
        {
            return floor;
        }

        public double getSquare()
        {
            return square;
        }

        public uint getLodgers()
        {
            return lodgers;
        }
        /* -------------------------------------------------------------------------- */


        /// <summary>
        /// Определяет тип здания по заданным при строительстве параметрам:
        /// Жильцы наличиствуют только в жилых зданиях,
        /// Складские помещения - одноэтажные,
        /// Офисные здания - многоэтажные и в них никто не проживает.
        /// </summary>
        /// <returns>Возвращает тип здания</returns>
        public string kindOfBilding()
        {
            if (lodgers == 0)
            {
                if (floor == 1)
                {
                    return "Storage";
                }
                else
                {
                    return "Office";
                }
            }
            else
            {
                return "House";
            }
        }
    }
}
