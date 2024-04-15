using System;

namespace Test_3
{
    /// <summary>
    /// <brief>Базовый класс "Координаты точки"</brief>
    /// Данный класс нужен для хранения и обработки информации об одной точке
    /// </summary>
    class Coord_point
    {
        protected double __grad = 0;// градусы
        protected double __min = 0;// минуты 
        protected double __sec = 0;// секунды
        /// <summary>
        /// Конструктор класса Coord_point, инициализирующий переменные
        /// </summary>
        /// <param name="__grad">градусы</param>
        /// <param name="__min">минуты</param>
        /// <param name="__sec">секунды</param>
        public void Init(double grad, double min, double sec)
        {
            this.__grad = grad;
            this.__min = min;
            this.__sec = sec;
        }
        /// <summary>
        /// <brief>Базовый объекты класса "Координаты точки"</brief>
        /// </summary>
        public Coord_point(double grad1, double min1, double sec1)
        {
            __grad = grad1;
            __min = min1;
            __sec = sec1;
        }
        /// <summary>
        /// Округляет полученные значения до градусов
        /// </summary>
        public int Rounding()
        {
            if (__sec >= 30 && __sec <= 60)
            {
                __min = __min + 1;
                __sec = 0;
            }
            else if (__sec >= 90)
            {
                __min = __min + 2;
                __sec = 0;
            }
            if (__min >= 30 && __min <= 60)
            {
                __grad = __grad + 1;
                __min = 0;
            }
            else if (__min >= 90)
            {
                __grad = __grad + 2;
                __min = 0;
            }
            return 0;
        }
        /// <summary>
        /// Отображает координаты точки
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Градусы = {0}, Минуты = {1}, Секунды = {2}", __grad, __min, __sec);
        }
    }
    /// <summary>
    /// <brief>Производный класс "Долгота"</brief>
    /// Обычный дочерний класс, который отнаследован от ранее созданного класса Coord_point
    /// </summary>
    class longitude : Coord_point // наследование                                 
    {
        //a. В производном классе добавляется указанное поле private.
        private float L;// долгота
        /// <summary>
        /// <brief>Базовый объекты класса "Долгота"</brief>
        /// </summary>
        public longitude(double grad1, double min1, double sec1, float lon1) : base(grad1, min1, sec1)
        {
            L = lon1;
        }
        /// <summary>
        /// Конструктор класса Coord_point, инициализирующий переменные
        /// </summary>
        /// ![Image](C:\Users\joppa\Desktop\img1.png)
        /// <param name=" L">долгота</param>
        /// ![Image](C:\Users\joppa\Desktop\images.jfif)
        public void Init(double grad, double min, double sec, float lon)//d. Выполняется перегрузка функций Init, Display для производного класса с вызовом функции базового класса.
        {
            base.Init(grad, min, sec);
            L = lon;
        }
        /// <summary>
        /// Перегруженный метод для округления координаты точки
        /// </summary>
        /// При округлении до градусов (целое число) учитывается расположении точки на полушариях:
        /// \f$ grad = grad \times  L \f$

        public void Rounding()//c. Метод базового класса перегружается для производного с учетом нового поля, при этом базовый  метод не вызывается, а доступ к полям базового класса обеспечивает  модификатор protected.
        {
            if (__sec >= 30 && __sec <= 60)
            {
                __min = __min + 1;
                __sec = 0;
            }
            else if (__sec >= 90)
            {
                __min = __min + 2;
                __sec = 0;
            }
            if (__min >= 30 && __min <= 60)
            {
                __grad = __grad + 1;
                __min = 0;
            }
            else if (__min >= 90)
            {
                __grad = __grad + 2;
                __min = 0;
            }
            if (L < 0)
                __grad = __grad * L;
        }
        /// <summary>
        /// Отображает координаты точки
        /// </summary>
        public void Display()//d. Выполняется перегрузка функций Init, Display для производного класса с вызовом функции базового класса.
        {
            base.Display();
            Console.WriteLine("Lon= {0}", L);
        }
    }
    /// <summary>
    /// <brief>Класс "Program"</brief>
    /// Данный класс нужен для исполнения кода
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            longitude ll = new longitude(1, 1, 1, -1);//e. В базовом и производном классах создать конструкторы с параметрами.Продемонстрировать в конструкторе производного класса с параметрами вызов конструктора базового класса.
            ll.Display();
            ll.Init(1, 40, 30, -1);
            ll.Rounding();
            ll.Display();
        }
    }
}

