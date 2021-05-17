using System;
using System.Collections.Generic;
using System.Text;

namespace Lr7
{
    class Fraction : IComparable, IEquatable<Fraction>
    {
        public int n;
        public int m;
        public string finalResult { get; set; }

        public Fraction(string num)
        {
            defineFormat(num);
            finalResult = num;
        }
        public Fraction(int a, int b)
        {
            n = a;
            m = b;
            finalResult = $"{n}/{m}";
        }

        public Fraction() { }

        public bool Equals(Fraction other)
        {
            int commondem = ComDen(this.m, other.m, other);
            int multiply1 = commondem / this.m;
            int multiply2 = commondem / other.m;

            this.Contract();
            other.Contract();

            if (this.n * multiply1 == other.n * multiply2)
                return true;

            return false;
        }

        public int CompareTo(object obj)
        {
            Fraction other = obj as Fraction;

            other.Contract();
            this.Contract();


            if (this.m == other.m)
            {
                return (this.n).CompareTo(other.n);
            }
            else if (this.m != other.m)
            {

                int commondem = ComDen(this.m, other.m, other);
                int multiply1 = commondem / this.m;
                int multiply2 = commondem / other.m;
                return (this.n * multiply1).CompareTo(other.n * multiply2);

            }
            if (obj == null) return 1;
            else
                return 2;
        }

        private int ComDen(int a, int b, Fraction r)
        {

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return Math.Abs(m * r.m) / a;
        }

        public void defineFormat(string num) //определение формата по введенной строке
        {
            if (String.IsNullOrWhiteSpace(num))
            {
                
            }
            int format = 2;  //по дефолту стоит 2 - для целочисленного типа
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '/')
                {
                    format = 0;
                    break;
                }
                else if (num[i] == '.' || num[i] == ',')
                {
                    format = 1;
                    break;
                }
                else if (!int.TryParse(num, out int type))
                {
                    format = 3;
                }
            }

            //если предыдущий код не нашел ни точки, ни запятой, ни знака деления, то дальше идет проверка на "специальный" формат
            string[] s_form = num.Split(' ');
            for (int i = 0; i < s_form.Length; i++)
            {
                if (s_form[i] == "из")
                {
                    int type;
                    if (int.TryParse(s_form[i - 1], out type))
                    {
                        Console.WriteLine(num);
                        n = int.Parse(s_form[i - 1]);
                    }
                    else if (int.TryParse(s_form[i - 2], out type))
                    {
                        n = int.Parse(s_form[i - 2]);
                    }
                    else if (int.TryParse(s_form[i - 3], out type))
                    {
                        n = int.Parse(s_form[i - 3]);
                    }
                    else
                    {

                        
                    }
                    m = int.Parse(s_form[i + 1]);
                    return;
                }
            }

            if (format == 3)
            {
                
            }

            //далее идет разбивка (если строка с точкой(запятой) или со знаком деления)
            StringBuilder _temp = new StringBuilder();
            int pos = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '/' || num[i] == '.' || num[i] == ',')
                {
                    pos = i + 1;
                    break;
                }
                else
                {
                    _temp.Append(num[i]);
                }
            }
            string temp = _temp.ToString();
            int a = int.Parse(temp);   //первая часть строки, ДО точки(запятой) или знака деления

            StringBuilder _temp2 = new StringBuilder();
            for (int i = pos; i < num.Length; i++)
            {
                _temp2.Append(num[i]);
            }
            string temp2 = _temp2.ToString();
            int b = int.Parse(temp2); //ну и соотвественно та часть строки после точки(запятой) или знака деления

            if (format == 0) //если строка содержит знак деления
            {
                n = a;
                m = b;
            }
            else if (format == 1) //если была введена десятичная дробь
            {
                int pdten = (int)Math.Pow(10, temp2.Length);
                if (a > 0)
                {
                    n = b + (pdten * a);
                }
                else
                {
                    n = b;
                }
                m = pdten;
                chooseFormat("0");
            }
            else //если было введено целое число
            {
                n = a;
                m = 1;
            }
        }

        public int chooseFormat(string pick)
        {
            Contract();
            switch (pick)
            {
                case "0": finalResult = ((double)n / m).ToString(); break;
                default: finalResult = $"{n}/{m}"; break;
            }
            return 0;
        }

        public void Contract()
        {
            int a = n;
            int b = m;
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            n /= a;
            m /= b;
        }

        public override string ToString()
        {
            return finalResult;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            a.Contract();
            b.Contract();
            int commondem = a.ComDen(a.m, b.m, b);
            int multiply1 = commondem / a.m;
            int multiply2 = commondem / b.m;

            if (a.m == b.m)
            {
                return new Fraction(a.n + b.n, a.m);
            }
            else
            {
                return new Fraction((a.n * multiply1) + (b.n * multiply2), commondem);
            }
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int commondem = a.ComDen(a.m, b.m, b);
            int multiply1 = commondem / a.m;
            int multiply2 = commondem / b.m;

            if (a.m == b.m)
            {
                return new Fraction(a.n - b.n, a.m);
            }
            else
            {
                return new Fraction((a.n * multiply1) - (b.n * multiply2), commondem);
            }
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            a.Contract();
            b.Contract();
            return new Fraction(a.n * b.n, a.m * b.m);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            a.Contract();
            b.Contract();
            return new Fraction(a.n * b.m, a.m * b.n);
        }

        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.n, a.m);
        }

        public static Fraction operator ++(Fraction a)
        {
            return new Fraction(a.n + a.m, a.m);
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            a.Contract();
            b.Contract();
            int _t = a.CompareTo(b);
            if (_t == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            a.Contract();
            b.Contract();
            int _t = a.CompareTo(b);
            if (_t == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            a.Contract();
            b.Contract();
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            a.Contract();
            b.Contract();
            return !a.Equals(b);
        }

        public static explicit operator int(Fraction a)
        {
            double _d = (double)a;
            double mod = _d - Math.Truncate(_d);
            if (mod >= 0.5)
            {
                return (a.n / a.m) + 1;
            }
            else
            {
                return a.n / a.m;
            }
        }

        public static implicit operator Fraction(double a)
        {
            return new Fraction(a.ToString());
        }

        public static implicit operator Fraction(int a)
        {
            return new Fraction(a, 1);
        }

        public static explicit operator double(Fraction a)
        {
            return (double)a.n / a.m;
        }
    }
}