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
        int Menu() {
            int value = 0;
            do
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1.Выполнить арифметические операции");
                Console.WriteLine("2.Выйти");
                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out value) )
                {
                    if(value == 1 || value == 2)
                    return value;
                }
                Console.WriteLine("Вы ввели неверное значение, попробуй те еще раз");
            } while (true);
        }

        public double EnterExpression() {
            string sign;
            bool isNotVerifide = true, isSign = false;
            float a = 0;
            float b = 0;
            double result = 0;
            int n;
            float stepen;

       

            do
            {
                isSign = true;

                Console.Write("Выберите действие, которое вы хотите сделать ('+'- сумма, '-' - вычитание," +
                    " '*' - умножение, '/' - деление, '%' - остаток от деления, 'pow' - возведение в степень 'sqrt' - корень n-ой степени): ");
                sign = Console.ReadLine();

                do
                {
                    Console.Write("Введите первое значение: ");
                    if (float.TryParse(Console.ReadLine(), out a))
                    {
                        if (sign != "pow")
                        {
                            if (sign != "sqrt")
                            {
                                do
                                {
                                    Console.Write("Введите второе значение: ");
                                    if (float.TryParse(Console.ReadLine(), out b))
                                    {
                                        isNotVerifide = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы ввели неверное значение, попробуйте еще раз\n");
                                    }
                                } while (isNotVerifide);
                            }
                        }
                        isNotVerifide = false;

                    }
                    else
                    {
                        Console.WriteLine("Вы ввели неверное значение, попробуйте еще раз");
                    }
                } while (isNotVerifide);


                switch (sign)
                {
                    case "+":
                        result = a + b;
                        break;

                    case "-":
                        result = a - b;

                        break;

                    case "*":
                        result = a * b;
                        break;

                    case "/":
                        result = a / b;
                        break;

                    case "%":
                        result = a % b;
                        break;

                    case "pow":
                        do
                        {
                            Console.Write("Введите степень: ");
                            if (int.TryParse(Console.ReadLine(), out n))
                            {
                                isNotVerifide = false;
                                result = Math.Pow(a, n);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Нужно ввестицелое число!");
                            }
                        } while (isNotVerifide);
                        break;

                    case "sqrt":
                        isNotVerifide = true;
                        do
                        {
                            Console.Write("Введите степень корня: ");
                            if (int.TryParse(Console.ReadLine(), out n))
                            {
                                stepen = (float) 1 / n;
                                isNotVerifide = false;
                                result = Math.Pow(a, stepen );
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Нужно ввестицелое число!");
                            }
                        } while (isNotVerifide);
                        break;

                    default:
                        isSign = false;
                        Console.WriteLine("Вы ввели неверный символ");
                        break;       
                }


            } while (!isSign);

            return result;

        }

        static void Main(string[] args)
        {
            Program program = new Program();
            bool is_exit = true;
            double result;

            do
            {
                if (program.Menu() == 1) {
                    result = program.EnterExpression();
                    result = Math.Round( (result * 10000)) / 10000;
                    Console.WriteLine("Ответ: " + result + "\n");
                }
                
            } while (is_exit);
        }
    }
}

