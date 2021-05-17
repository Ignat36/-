using System;

namespace Lr7
{   class Program
    {
        static void checkPick(ref string str, int n)
        {
            bool isPicked = false;
            while (!isPicked)
            {
                for (int i = 0; i < n; i++)
                {
                    if (str == i.ToString())
                    {
                        isPicked = true;
                    }
                }
                if (isPicked == true)
                {
                    continue;
                }
                Console.WriteLine("Неверный ввод. Выберете действие из предложенных сверху: ");
                str = Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("0. Представление дроби в разных форматах\n" +
                              "1. Сложение дробей\n" +
                              "2. Вычитание дробей\n" +
                              "3. Умножение дробей\n" +
                              "4. Деление дробей\n" +
                              "5. Сравнение дробей");
            string wtd = Console.ReadLine();
            bool isPicked = false;
            while (!isPicked)
            {
                if (wtd == "0" || wtd == "1" || wtd == "2" || wtd == "3" || wtd == "4" || wtd == "5")
                {
                    isPicked = true;
                    continue;
                }
                Console.WriteLine("Неверный ввод. Выберете действие из предложенных сверху: ");
                wtd = Console.ReadLine();
            }
            switch (wtd)
            {
                case "0":
                    {
                        string _ratio = null;
                        Fraction ratt;
                        Console.Write("Введите рациональное число: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                ratt = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        ratt = new Fraction(_ratio);
                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь\n2. Приведение к целочисленному типу");

                        string pick = Console.ReadLine();
                        checkPick(ref pick, 3);
                        ratt.chooseFormat(pick);
                        if (pick == "2")
                        {
                            Console.WriteLine((int)ratt);
                        }
                        else
                        {
                            ratt.chooseFormat(pick);
                            Console.WriteLine(ratt.ToString());
                        }
                        break;
                    }
                case "1":
                    {
                        string _ratio = null;
                        Fraction _ratio1;
                        Console.WriteLine("Введите первую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio1 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction first = new Fraction(_ratio);

                        _ratio = null;
                        Fraction _ratio2;
                        Console.WriteLine("Введите вторую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio2 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction second = new Fraction(_ratio);
                        Fraction result = first + second;

                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь");

                        string pick = Console.ReadLine();
                        checkPick(ref pick, 2);
                        result.chooseFormat(pick);

                        Console.WriteLine("Результат сложения: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "2":
                    {
                        string _ratio = null;
                        Fraction _ratio1;
                        Console.WriteLine("Введите первую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio1 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction first = new Fraction(_ratio);

                        _ratio = null;
                        Fraction _ratio2;
                        Console.WriteLine("Введите вторую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio2 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction second = new Fraction(_ratio);
                        Fraction result = first - second;

                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь");

                        string pick = Console.ReadLine();
                        checkPick(ref pick, 2);
                        result.chooseFormat(pick);

                        Console.WriteLine("Результат вычитания: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "3":
                    {
                        string _ratio = null;
                        Fraction _ratio1;
                        Console.WriteLine("Введите первую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio1 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction first = new Fraction(_ratio);

                        _ratio = null;
                        Fraction _ratio2;
                        Console.WriteLine("Введите вторую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio2 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction second = new Fraction(_ratio);
                        Fraction result = first * second;

                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь");

                        string pick = Console.ReadLine();
                        checkPick(ref pick, 2);
                        result.chooseFormat(pick);

                        Console.WriteLine("Результат умножения: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "4":
                    {
                        string _ratio = null;
                        Fraction _ratio1;
                        Console.WriteLine("Введите первую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio1 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction first = new Fraction(_ratio);

                        _ratio = null;
                        Fraction _ratio2;
                        Console.WriteLine("Введите вторую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio2 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction second = new Fraction(_ratio);
                        Fraction result = first / second;

                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь");

                        string pick = Console.ReadLine();
                        checkPick(ref pick, 2);
                        result.chooseFormat(pick);

                        Console.WriteLine("Результат деления: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "5":
                    {
                        string _ratio = null;
                        Fraction _ratio1;
                        Console.WriteLine("Введите первую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio1 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction first = new Fraction(_ratio);

                        _ratio = null;
                        Fraction _ratio2;
                        Console.WriteLine("Введите вторую дробь: ");
                        while (_ratio == null)
                        {
                            try
                            {
                                _ratio = Console.ReadLine();
                                _ratio2 = new Fraction(_ratio);
                            }
                            catch (StringException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (EnterKeyException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                            catch (WordsException ex)
                            {
                                Console.Write($"{ex.Message} Повторите ввод: ");
                                _ratio = null;
                            }
                        }

                        Fraction second = new Fraction(_ratio);
                        Console.WriteLine("Результат: ");

                        if (first == second)
                        {
                            Console.WriteLine($"{first.ToString()} = {second.ToString()}");
                        }
                        else if (first < second)
                        {
                            Console.WriteLine($"{first.ToString()} < {second.ToString()}");
                        }
                        else if (first > second)
                        {
                            Console.WriteLine($"{first.ToString()} > {second.ToString()}");
                        }
                        break;
                    }
            }
        }
    }
}