using System;
using System.Linq;

namespace AppTest
{
    public static class StupidMaths
    {
        #region Homework1

        //1. Функция удаляет из списка каждый второй элемент(на вход элементы массива перечисленные через запятую в строке, к примеру, "1.2, 2, 3.5").
        public static string RemoveEvens(string input)
        {
            var array = input.Split(',');
            if (array.Length < 2)
                return input;
            var result = new string[(int)Math.Round(array.Length / 2d)];

            for (int i = 0, j = 0; i < array.Length; i++)
                if (i % 2 == 0)
                    result[j++] = array[i];

            return string.Join(",", result);
        }

        //2. Найти корни квадратного уравнения, заданного своими коэффициентами.Предусмотреть все возможные случаи (два действительных корня, один корень, нет корней). На вход коэф.a,b,c(тип double).
        public static double[] SolveEquaiton(double a, double b, double c, double tolerance = 0.000001)
        {
            if(Math.Abs(a) < tolerance)
                return new double[0];
            var D = b * b - 4 * a * c;

            if (Math.Abs(D) < tolerance)
                return new[] { -b / 2 * a };
            if (D > 0)
                return new[] {(-b + Math.Sqrt(D)) / (2 * a), (-b - Math.Sqrt(D)) / (2 * a)};
            return new double[0];
        }

        //3. Положения ферзей на шахматной доске заданы списком пар(горизонталь, вертикаль). Определить, имеется ли пара ферзей, бьющих друг друга.
        public static bool DoCapture(Tuple<byte, byte>[] positions)
        {
            if (positions.Any(e => e.Item1 >= 8 || e.Item2 >= 8))
                return false;

            for (int i = 0; i < positions.Length - 1; i++)
                for (int j = i+1; j < positions.Length; j++)
                {
                    var a = positions[i];
                    var b = positions[j];

                    if (a.Item1 == b.Item1 || a.Item2 == b.Item2)
                        return true;
                    if (Math.Abs(a.Item1 - b.Item1) == Math.Abs(a.Item2 - b.Item2))
                        return true;
                }

            return false;
        }

        #endregion
        
        #region Lesson1

        public static int[] ParseNumbers(string input)
        {
            var normalInput = input.Replace(","," ").Replace("  ", " ").Trim();
            var strings = normalInput.Split(' ');
            var nums = new int[strings.Length];

            if (normalInput == String.Empty)
                return new int[0];

            int j = 0;
            for (var i = 0; i < strings.Length; i++)
            {
                nums[i] = 0;
                if (int.TryParse(strings[i], out nums[i]))
                    j++;
            }

            var result = new int[j];
            for (int i = 0, k = 0; i < nums.Length && k < j; i++)
                result[k++] = strings[i] == nums[i].ToString() ? nums[i] : k--;
            return result;
        }

        public static int Sum(int[] array)
        {
            var result = 0;
            foreach (var t in array)
                result += t;
            return result;
        }


        #endregion
    }
}
