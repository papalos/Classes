using System;


namespace Geometric
{
    /* -------------------------------------- Точка -------------------------------- */
    class Point
    {
        private int _x;
        private int _y;

        /* Конструктор */
        public Point(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        /* --- Сетеры и Гетеры ---*/
        public int x { get { return _x; } set { _x = value; } }
        public int y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Расстояние от начала координат до точки
        /// </summary>
        /// <returns>длина вектора</returns>
        public double distance()
        {
            return Math.Sqrt(x * x + y * y);
        }

    }



   /* ------------------------------------ Отрезок ------------------------------------- */
    class Line
    {
        private Point _pointStart;
        private Point _pointEnd;

        public Line(Point st, Point end)
        {
            _pointStart = st;
            _pointEnd = end;
        }

        public Point pointStart { get { return _pointStart; } set { _pointStart = value; } }
        public Point pointEnd { get { return _pointEnd; } set { _pointEnd = value; } }

        /// <summary>
        /// Длина линии. 
        /// Вычитание векторов методом треугольника
        /// Разность векторов описывающих точку будет длиной отрезка между этими точками
        /// </summary>
        public double lenght()
        {
            return Math.Sqrt(Math.Pow((pointEnd.x - pointStart.x), 2) + Math.Pow((pointEnd.y - pointStart.y), 2));
        }

        /// <summary>
        /// проверяет лежит ли заданная точка на данном отрезке. 
        /// </summary>
        /// <param name="exam">проверяемая точка</param>
        /// <returns>true-если принадлежит, false-если не принадлежит</returns>
        public bool isPointOnLine(Point exam)
        {
            if (((exam.x - pointStart.x) / (pointEnd.x - pointStart.x)) == ((exam.y - pointStart.y) / (pointEnd.y - pointStart.y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
    
    /* ------------------------------------ Квадрат ------------------------------------ */
    class Square
    {
        private Point _startSquarePoint;
        private Line _lenghtSide;

        /* Конструктор \п */
        public Square(Point leftTopAngle, int side)
        {
            _startSquarePoint = leftTopAngle;
            _lenghtSide = new Line(leftTopAngle, new Point(leftTopAngle.x + side, leftTopAngle.y));
        }


        public Point startSquarePoint { get { return _startSquarePoint; } set { _startSquarePoint = value; } }
        public Line lenghtSide { get { return _lenghtSide; } set { _lenghtSide = value; } }


        /* Площадь квадрата */
        public double square()
        {
            return _lenghtSide.lenght() * _lenghtSide.lenght();
        }

        /* Периметр */
        public double perimeter()
        {
            return 4 * _lenghtSide.lenght();
        }

        /// <summary>
        /// Проверяет принадлежность точки к квадрату
        /// </summary>
        /// <param name="point">исследуемая точка</param>
        /// <returns>true-если принадлежит, false-если не принадлежит</returns>
        public bool isPointInSquare(Point point)
        {
            if ((point.x >= _startSquarePoint.x & point.x <= (_startSquarePoint.x + _lenghtSide.lenght()))
                & (point.y <= _startSquarePoint.y & point.y >= (_startSquarePoint.y - _lenghtSide.lenght())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    
    /* ----------------------------------- Круг ---------------------------------------- */
    class Circle
    {
        private Point _center;
        private Line _radius;

        /* Конструктор */
        public Circle(Point center, int lenghtRadius)
        {
            this._center = center;
            this._radius = new Line(center, new Point(center.x + lenghtRadius, center.y));
        }

        public Point center { get { return _center; } set { _center = value; } }
        public Line redius { get { return _radius; } set { _radius = value; } }

        /// <summary>
        /// Проверяет вхождение точки в круг
        /// </summary>
        /// <param name="point">проверяемая точка</param>
        /// <returns>возвращает истину или ложь</returns>
        public bool isPointInCircle(Point point)
        {
            if (Math.Sqrt(Math.Pow(_center.x - point.x, 2) + Math.Pow(_center.y - point.y, 2)) <= _radius.lenght())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Длина окружности */
        public double circumference()
        {
            return 2 * Math.PI * _radius.lenght();
        }

        /* Площадь круда */
        public double square()
        {
            return (_radius.lenght() * circumference()) / 2;
        }
    }

    

    /* ----------------------------------- Прямоугольник ------------------------------ */
    class Rectangle
    {
        private Point _leftTopAngle;
        private Line _width;
        private Line _lenght;

        /* Конструктор */
        public Rectangle(Point leftTopAngle, int width, int lenght)
        {
            this._leftTopAngle = leftTopAngle;
            this._width = new Line(leftTopAngle, new Point(leftTopAngle.x, leftTopAngle.y + width));
            this._lenght = new Line(leftTopAngle, new Point(leftTopAngle.x + width, leftTopAngle.y));
        }

        public Point leftTopAngle { get { return _leftTopAngle; } set { _leftTopAngle = value; } }
        public Line width { get { return _width; } set { _width = value; } }
        public Line lenght { get { return _lenght; } set { _lenght = value; } }

        /* Площадь прямоугольника */
        public double square()
        {
            return _width.lenght() * _lenght.lenght();
        }

        /* Периметр  прямоугольника */
        public double perimeter()
        {
            return 2 * _width.lenght() + 2 * _lenght.lenght();
        }

        /// <summary>
        /// Проверяет принадлежность точки к прямоугольнику
        /// </summary>
        /// <param name="point">исследуемая точка</param>
        /// <returns>true-если принадлежит, false-если не принадлежит</returns>
        public bool isPointInSquare(Point point)
        {
            if ((point.x >= _leftTopAngle.x & point.x <= (_leftTopAngle.x + _lenght.lenght()))
                & (point.y <= _leftTopAngle.y & point.y >= (_leftTopAngle.y - _lenght.lenght())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    
    /* ----------------------------------- Ромб ------------------------------------------ */
    class Rhomb
    {
        private Point _centralPoint;
        private Line _verticalHalfDiagonal;
        private Line _horizontalHalfDiagonal;

        /* Конструктор */
        public Rhomb(Point centralPoint, int verticalDiagonal, int horizontalDiagonal)
        {
            this._centralPoint = centralPoint;
            this._verticalHalfDiagonal = new Line(centralPoint, new Point(centralPoint.x, centralPoint.y + (verticalDiagonal / 2)));
            this._horizontalHalfDiagonal = new Line(centralPoint, new Point(centralPoint.x + (horizontalDiagonal / 2), centralPoint.y));
        }

        public Point centralPoint { get { return _centralPoint; } set { _centralPoint = value; } }
        public Line verticalHalfDiagonal { get { return _verticalHalfDiagonal; } set { _verticalHalfDiagonal = value; } }
        public Line horizontalHalfDiagonal { get { return _horizontalHalfDiagonal; } set { _horizontalHalfDiagonal = value; } }

        /* Площадь ромба */
        public double square()
        {
            return 2 * _verticalHalfDiagonal.lenght() * _horizontalHalfDiagonal.lenght();
        }

        /* Периметр ромба */
        public double perimeter()
        {
            return 4 * Math.Sqrt(Math.Pow(_verticalHalfDiagonal.lenght(), 2) + Math.Pow(_horizontalHalfDiagonal.lenght(), 2));
        }

        /// <summary>
        /// Принадлежит ли точка Ромбу
        /// </summary>
        /// <param name="point">Исследуемая точка</param>
        /// <returns>true-если принадлежит, false-если не принадлежит</returns>
        public bool isPointInRhomb(Point point)
        {
            if ((Math.Abs(point.x - _centralPoint.x) / _horizontalHalfDiagonal.lenght())
               + (Math.Abs(point.y - _centralPoint.y) / _verticalHalfDiagonal.lenght()) <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}