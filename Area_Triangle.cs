using System;
using System.Runtime.Serialization;


namespace Area
{

    public class Area_Triangle
    {
        /// <summary>
        /// Код для нахождения площади прямоугольного треугольника. (Допустима погрешность при вводе гипотенузы до 0.01)
        /// </summary>
        /// <param name="a">Сторона треугольника/param>
        /// <param name="b">Сторона треугольника/param>
        /// <param name="c">Сторона треугольника/param>
        /// <returns>Площадь прямоугольного треугольника</returns>
        public const string Area_right_Triangle_SidesLessThanZero = "Введены не корректные значения сторон.";
        public const string Area_right_Triangle_TriangleIsNotRight = "Введенный треугольник не является прямоугольным.";



        public static double area_right_triangle(double a, double b, double c)
        {
            // Если одна из сторон была введена с ошибкой  - Выводим исключение с сообщением о возникшей проблеме
            if (a < 0 || b < 0 || c < 0)
            {
                throw new userExeption(Area_right_Triangle_SidesLessThanZero);
            }


            // Находим гипотенузу
            // переставляем гипотенузу на переменную с (для удобства вычисления внутри в функции)
            if ((a > b) && (a > c))
            {
                a = a + c;
                c = a - c;
                a = a - c;
            }
            else if ((b > a) && (b > c))
            {
                b = b + c;
                c = b - c;
                b = b - c;
            }

            // Проверка прямоугольности треугольника с помощью теоремы Пифагора (допускается погрешность при вводе гипотенузы до 0.01)
            if (Math.Abs(c - Math.Sqrt(a * a + b * b)) > 0.01)
            {
                throw new userExeption(Area_right_Triangle_TriangleIsNotRight);
            }

            // Вычисление площади прямоугольного треугольника
            return a * b/2;
        }



    }


    // Описание пользовательского исключения
    [Serializable]
    public class userExeption : Exception
    {
        public userExeption()
        {
        }

        public userExeption(string message) : base(message)
        {
        }

        public userExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected userExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }


}


