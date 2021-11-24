using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Contracts;

namespace LabaPiA4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Индесы минимальных элементов строк матрицы - {0}", string.Join(" ", FirstSix()));
            Console.WriteLine();
            Console.WriteLine("Максимальные элементы столбцов матрицы - {0}", string.Join(" ", FirstSeven()));
            Console.WriteLine();
            Console.WriteLine("Средние значения среди положительных элементов матрицы - {0}", string.Join(" ", FirstEight()));
            Console.WriteLine();
            SecondSix();
            Console.WriteLine();
            PrintMatrix("Матрица с нулями в строках и столбцах правее главной диагонали - ", SecondSeven());
            Console.WriteLine();
            PrintMatrix("Матрица, где поменяны местами максимальные элементы 1-й и 2-й строк, 3-й и 4-й, 5-й и 6-й - ", SecondEight());
            Console.WriteLine();
            ThirdSix();
            Console.WriteLine();
            ThirdSeven();
            Console.WriteLine();
            ThirdEight();
        }

        /// Сформировать одномерный массив из индексов минимальных элементов столбцов матрицы А размера 4 × 7.
        private static int[] FirstSix()
        {
            const int n = 4;
            const int m = 7;
            int[,] matrix = RandomMatrix(n, m);

            Console.WriteLine("Исходная матрица - ");
            PrintMatrix(matrix);

            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int min = matrix[0, i];
                int index = 0;
                for (int j = 0; j < m; j++)
                {
                    if (min > matrix[j, i])
                    {
                        min = matrix[j, i];
                        index = j;
                    }
                }
                result[i] = index;
            }

            return result;
        }

        /// Сформировать одномерный массив из значений максимальных элементов столбцов матрицы А размера 3 × 5.
        private static int[] FirstSeven()
        {
            const int n = 3;
            const int m = 5;
            int[,] matrix = RandomMatrix(n, m);

            Console.WriteLine("Исходная матрица - ");
            PrintMatrix(matrix);

            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int max = matrix[0, i];
                for (int j = 0; j < m; j++)
                {
                    if (max < matrix[j, i])
                    {
                        max = matrix[j, i];
                    }
                }
                result[i] = max;
            }

            return result;
        }

        /// Сформировать одномерный массив из средних значений среди положительных элементов строк матрицы А размера 4 × 6.
        static private int[] FirstEight()
        {
            const int n = 4;
            const int m = 6;
            int[,] matrix = RandomMatrix(n, m);

            Console.WriteLine("Исходная матрица - ");
            PrintMatrix(matrix);

            int[] result = new int[m];

            for (int i = 0; i < m; i++)
            {
                int sum = 0;
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] >= 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                result[i] = sum / count;
            }

            return result;
        }

        /// Сформировать матрицу размера n * 3n, составленную из трех единичных квадратных матриц размера n * n.
        static private int[,] SecondSix()
        {
            int n = random.Next(1, 4);
            int[,] initual_matrix_0 = RandomMatrix(n, n);
            int[,] initual_matrix_1 = RandomMatrix(n, n);
            int[,] initual_matrix_2 = RandomMatrix(n, n);

            Console.WriteLine("Исходная матрица 0 - ");
            PrintMatrix(initual_matrix_0);
            Console.WriteLine("Исходная матрица 1 - ");
            PrintMatrix(initual_matrix_1);
            Console.WriteLine("Исходная матрица 2 - ");
            PrintMatrix(initual_matrix_2);

            int[,] result = new int[3 * n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = initual_matrix_0[i, j];
                    result[i + n, j] = initual_matrix_1[i, j];
                    result[i + n * 2, j] = initual_matrix_2[i, j];
                }
            }

            Console.WriteLine("Матрица составленая из 3 матриц - ");
            PrintMatrix(result);
            return result;
        }

        // В матрице А размера 6 × 6 найти максимальный элемент на главной диагонали.
        // Заменить нулями элементы матрицы, расположенные правее главной диагонали в
        // строках, расположенных выше строки, содержащей максимальный элемент на
        // главной диагонали.
        static private int[,] SecondSeven()
        {
            int n = 6;
            int[,] matrix = RandomMatrix(n, n);

            Console.WriteLine("Исходная матрица - ");
            PrintMatrix(matrix);

            int max = matrix[0, 0];
            int index = 0;
            for (int i = 1; i < n; i++)
            {
                if (max < matrix[i, i])
                {
                    max = matrix[i, i];
                    index = i;
                }
            }

            for (int i = 0; i < index; i++)
                for (int j = i + 1; j < n; j++)
                    matrix[i, j] = 0;


            return matrix;
        }

        /// В матрице В размера 6 × 6 поменять местами максимальные элементы 1-й и 2-й строк, 3-й и 4-й, 5-й и 6-й.
        static private int[,] SecondEight()
        {
            int n = 6;
            int[,] matrix = RandomMatrix(n, n);

            PrintMatrix("Исходня матрица - ", matrix);

            for (var i = 0; i < n; i += 2)
            {
                /// Найти индекс макисмального элемента в строке i и строке i+1
                int max_i = matrix[i, 0];
                int max_i_index = 0;
                int max_i_1 = matrix[i + 1, 0];
                int max_i_1_index = 0;
                for (int j = 1; j < n; j++)
                {
                    if (max_i < matrix[i, j])
                    {
                        max_i = matrix[i, j];
                        max_i_index = j;
                    }
                    if (max_i_1 < matrix[i + 1, j])
                    {
                        max_i_1 = matrix[i + 1, j];
                        max_i_1_index = j;
                    }
                }
                // Поменять местами элементы в строках i и i+1
                int temp = matrix[i, max_i_index];
                matrix[i, max_i_index] = matrix[i + 1, max_i_1_index];
                matrix[i + 1, max_i_1_index] = temp;
            }

            return matrix;
        }

        /// В матрице размера n  n сформировать два одномерных массива: в один переслать
        /// по строкам верхний треугольник матрицы, включая элементы главной диагонали, в
        /// другой – нижний треугольник. Вывести верхний и нижний треугольники по строкам.
        static private void ThirdSix()
        {
            int n = 6;
            int[,] matrix = RandomMatrix(n, n);

            PrintMatrix("Исходная матрица - ", matrix);

            int[] upper_triangle = new int[n * n];
            int[] lower_triangle = new int[n * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i <= j)
                        upper_triangle[i * n + j] = matrix[i, j];
                    else
                        lower_triangle[i * n + j] = matrix[i, j];
                }
            }

            Console.WriteLine("Верхний треугольник по строкам - [{0}]", string.Join(", ", upper_triangle));
            Console.WriteLine("Нижний треугольник по строкам - [{0}]", string.Join(", ", lower_triangle));
        }

        /// Перемножить две симметрические матрицы, заданные в одномерных массивах
        /// верхними треугольниками по строкам. Результат получить в одномерном массиве.
        /// Вывести в привычном виде исходные матрицы и матрицу-результат.
        static private void ThirdSeven()
        {
            int n = 6;
            int[] matrix_1 = ArrayFromMatrix(RandomMatrix(n, n));
            int[] matrix_2 = ArrayFromMatrix(RandomMatrix(n, n));

            Console.WriteLine("Исходная матрица 1 - [{0}]", string.Join(", ", matrix_1));
            Console.WriteLine("Исходная матрица 2 - [{0}]", string.Join(", ", matrix_2));

            int[] upper_triangle_1 = new int[n * n];
            int[] upper_triangle_2 = new int[n * n];
            int[] lower_triangle_1 = new int[n * n];
            int[] lower_triangle_2 = new int[n * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i <= j)
                    {
                        upper_triangle_1[i * n + j] = matrix_1[i * n + j];
                        upper_triangle_2[i * n + j] = matrix_2[i * n + j];
                    }
                    else
                    {
                        lower_triangle_1[i * n + j] = matrix_1[i * n + j];
                        lower_triangle_2[i * n + j] = matrix_2[i * n + j];
                    }
                }
            }

            int[] result = new int[n * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i * n + j] = upper_triangle_1[i * n + j] * upper_triangle_2[i * n + j] +
                                       lower_triangle_1[i * n + j] * lower_triangle_2[i * n + j];
                }
            }

            Console.WriteLine("Результат - [{0}]", string.Join(", ", result));
        }

        /// В матрице размера 7 × 5 переставить строки таким образом, чтобы количества
        /// положительных элементов в строках следовали в порядке убывания.
        static private void ThirdEight()
        {
            int[,] matrix = RandomMatrix(7, 5);

            PrintMatrix("Исходная матрица - ", matrix);

            var positive_count = new (int, int)[5];

            for (int i = 0; i < 5; i++)
            {
                positive_count[i] = (i, 0);
                for (int j = 0; j < 7; j++)
                {
                    if (matrix[i, j] >= 0)
                        positive_count[i].Item2++;
                }
            }

            Array.Sort(positive_count, (a, b) => b.Item2.CompareTo(a.Item2));
            var sorted_positive_count = positive_count.Select(x => x.Item1).ToList();

            int[,] sorted_matrix = new int[5, 7];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    sorted_matrix[i, j] = matrix[sorted_positive_count[i], j];
                }
            }

            PrintMatrix("Матрица после сортировки по количеству положительных элементов в строке - ", sorted_matrix);
        }

        /// <summary>
        /// Выводит в консоль матрицу
        /// </summary>
        /// <param name="matrix">Матрица, которую нужно напечатать</param>
        static private void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine("[");
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            for (int i = 0; i < n; ++i)
            {
                Console.Write("\t[{0}", matrix[i, 0]);
                for (int j = 1; j < m; ++j)
                    Console.Write(", {0}", matrix[i, j]);
                Console.WriteLine("],");
            }
            Console.WriteLine(']');

        }

        /// <summary>
        /// Превращает матрицу в одномерный массив
        /// </summary>
        /// <param name="matrix">Матрица, которую необходимо превратить</param>
        /// <returns>Массив содержащий элементы матрицы</returns>
        static public int[] ArrayFromMatrix(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            int[] array = new int[n * m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    array[i * m + j] = matrix[i, j];
                }
            }
            return array;
        }

        /// <summary>
        /// Выводит в консоль сначала сообщение start, потом матрицу
        /// </summary>
        /// <param name="start">Сообщение с которого надо начать вывод</param>
        /// <param name="matrix">Матрица, которую необходимо вывести</param>
        static public void PrintMatrix(string start, int[,] matrix)
        {
            Console.Write(start);
            PrintMatrix(matrix);
        }

        static private readonly Random random = new Random();

        /// <summary>
        /// Создает матрицу со случаными длинами и случайными значениями
        /// Также выводит её в консоль
        /// </summary>
        /// <returns>Созданая матрица</returns>
        static public int[,] RandomMatrix()
        {
            int n = random.Next(4, 7);
            int m = random.Next(4, 7);
            var matrix = RandomMatrix(n, m);
            Console.Write("Матрица со случайными значениями - ");
            PrintMatrix(matrix);
            return matrix;
        }

        /// <summary>
        /// Создает матрицу с заданной длиной и случайными значениями
        /// </summary>
        /// <param name="n">Количество рядов</param>
        /// <param name="m">Количество столбцов</param>
        /// <returns>Созданая матрица</returns>
        static private int[,] RandomMatrix(int n, int m)
        {
            int[,] matrix = new int[m, n];
            for (int j = 0; j < n; j++)
                for (int i = 0; i < m; i++)
                    matrix[i, j] = random.Next(-20, 20);
            return matrix;
        }

        /// <summary>
        /// Массив случайной длины со случайными элементами
        /// Также выводит этот массив в консоль
        /// </summary>
        /// <returns>Созданый массив</returns>
        static public int[] RandomArray()
        {
            var length = random.Next(4, 7);
            var list = RandomArray(length);
            Console.WriteLine("Рандомный массив - [{0}]", list);
            return list;
        }

        /// <summary>
        /// Массив длины length со случайными элементами
        /// </summary>
        /// <param name="length">Длина массива</param>
        /// <returns>Созданный массив</returns>
        static private int[] RandomArray(int length)
        {
            var list = new int[length];
            for (int i = 0; i < length; i++)
                list[i] = (random.Next(-20, 20));
            return list;
        }
    }
}
