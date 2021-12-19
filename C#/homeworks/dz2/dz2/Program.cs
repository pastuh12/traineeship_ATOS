using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace dz1
{
    class Program
    {


        public enum MenuOptions
        {
            ArifOperations = ConsoleKey.D1,
            NewArray = ConsoleKey.D2,
            ArrayOperations = ConsoleKey.D3,
            Exit = ConsoleKey.Escape
        }

        public enum ArifOperations
        {
            Plus = ConsoleKey.D1,
            Minus = ConsoleKey.D2,
            Multi = ConsoleKey.D3,
            Div = ConsoleKey.D4,
            Mod = ConsoleKey.D5,
            Pow = ConsoleKey.D6,
            Sqrt = ConsoleKey.D7
        }
        public enum ArrayOperations
        {
            Max = ConsoleKey.D1,
            Min = ConsoleKey.D2,
            Sum = ConsoleKey.D3,
            Average = ConsoleKey.D4,
            GeometAverage = ConsoleKey.D5
    }
    public MenuOptions Menu()
        {
            int key;
            while (true)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1 - Выполнить арифметические операции");
                Console.WriteLine("2 - Ввести новый массив элементов");
                Console.WriteLine("3 - Действия с массивом");
                Console.WriteLine("Esc - Выйти");
                Console.Write("Ваш выбор: ");

                key = (int)Console.ReadKey().Key;
                if (Enum.IsDefined(typeof(MenuOptions), key))
                {
                    return (MenuOptions)key;
                }
            }
        }
        public double enterExpression()
        {
            ArifOperations operation = 0;
            int key;
            double a = 0;
            double b = 0;
            int n;
            double stepen;

            Func<double, double, double> funcPlus = (x, y) => x + y;
            Func<double, double, double> funcMinus = (x, y) => x - y;
            Func<double, double, double> funcMulti = (x, y) => x * y;
            Func<double, double, double> funcDiv = (x, y) => x / y;
            Func<double, double, double> funcMod = (x, y) => x / y;
            Func<double, double, double> funcPow = (x, y) => Math.Pow(x, y);

            do
            {
                Console.Write("\nВыберите действие, которое вы хотите сделать: \n1 - сумма;" +
                    " \n2 - вычитание;" +
                    " \n3 - умножение;" +
                    " \n4 - деление;" +
                    " \n5 - остаток от деления;" +
                    " \n6 - возведение в степень;" +
                    " \n7 - корень n-ой степени" +
                    " \nВаш выбор: ");

                key = (int)Console.ReadKey().Key;
                Console.WriteLine();
                if (Enum.IsDefined(typeof(ArifOperations), key))
                {
                    operation = (ArifOperations)key;

                    do
                    {
                        Console.Write("Введите первое значение: ");
                        if (double.TryParse(Console.ReadLine(), out a))
                        {
                            do
                            {
                                Console.Write("Введите второе значение: ");
                                if (double.TryParse(Console.ReadLine(), out b))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Вы ввели неверное значение, попробуйте еще раз\n");
                                }
                            } while (true);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели неверное значение, попробуйте еще раз");
                        }
                    } while (true);
                }
                switch (operation)
                {
                    case ArifOperations.Plus:
                        return funcPlus(a, b);

                    case ArifOperations.Minus:
                        return funcMinus(a, b);

                    case ArifOperations.Multi:
                        return funcMulti(a, b);

                    case ArifOperations.Div:
                        return funcDiv(a, b);

                    case ArifOperations.Mod:
                        return funcMod(a, b);

                    case ArifOperations.Pow:
                        return funcPow(a, b);

                    case ArifOperations.Sqrt:
                        return funcPow(a, 1/b);

                    default:
                        Console.WriteLine("Вы ввели неверный символ");
                        break;
                }


            } while (true);

        }

        public int enterCountArrayElement()
        {
            int n;
            
            while (true)
            {
                Console.Write("\nВведите количество элементов массива: ");
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    return n;
                }
                Console.WriteLine("Вы ввели неверное значение");
                Console.Write("Попробуйте еще раз: ");

            }
        }
        public void enterArray(ref double[] array)
        {
            double element;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Элемент номер " + (i + 1) + ":");
                do
                {
                    if (double.TryParse(Console.ReadLine(), out element))
                    {
                        array[i] = element;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Нужно ввести число");
                    }
                } while (true);

            }
        }

        public void writeArray(ref double[] array)
        {
            Console.WriteLine("\nЭлементы вашего массива: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public double arrayOperation(ref double[] array)
        {
            ArrayOperations operation;
            int key;
            do
            {
                Console.Write("\nВыберите действие, которое вы хотите сделать: \n1 - максимум;" +
                    " \n2 - минимум;" +
                    " \n3 - сумма;" +
                    " \n4 - среднее арифметическое значение;" +
                    " \n5 - среднее геометрическое значение;" +
                    " \nВаш выбор: ");

                key = (int)Console.ReadKey().Key;
                Console.WriteLine();
                if (Enum.IsDefined(typeof(ArrayOperations), key))
                {
                    operation = (ArrayOperations)key;
                    while (true)
                    {

                        switch (operation)
                        {
                            case ArrayOperations.Max:
                                return array.Max();

                            case ArrayOperations.Min:
                                return array.Min();

                            case ArrayOperations.Sum:
                                return array.Sum();

                            case ArrayOperations.Average:
                                return array.Average();

                            case ArrayOperations.GeometAverage:
                                return Math.Round(Math.Pow(array.Aggregate(1d,
                                                                          (agr, next) =>
                                                                              agr *= next),
                                    (double)1 / array.Length) * 10000) / 10000;

                            default:
                                Console.WriteLine("Вы ввели не существующий вариант");
                                Console.Write("Попробуйте еще раз: ");
                                break;

                        }

                    }
                }
            } while (true);

        }

        static void Main(string[] args)
        {
            Program program = new Program();
            bool is_exit = true;
            MenuOptions operation;
            double result = 0;
            double[] array = new double[0];

            while (is_exit)
            {
                operation = program.Menu();
                if (operation == MenuOptions.ArifOperations)
                {
                    result = program.enterExpression();
                    result = Math.Round((result * 10000)) / 10000;
                    Console.WriteLine("Ответ: " + result + "\n");
                }
                if (operation == MenuOptions.NewArray)
                {
                    array = new double[program.enterCountArrayElement()];
                    program.enterArray(ref array);
                }
                if (operation == MenuOptions.ArrayOperations)
                {
                    if (array.Count() != 0)
                    {
                        program.writeArray(ref array);
                        result = program.arrayOperation(ref array);
                        Console.WriteLine("Ответ: " + result + "\n");
                    }
                    else
                    {
                        Console.WriteLine("\nСначало нужно заполнить массив");
                    }
                }
                is_exit = operation == 0 ? false : true;
            }
        }
    }
}

