using System;

namespace Calculator
{
    class Program
    {
        static void CheckExpression(string Expression, ref bool exit_Flag)
        {
            char cur, temp;
            int pos = 0;
            int brackets = 0;

            while (Expression[pos] == ' ')
                pos++;

            temp = Expression[pos];
            pos++;

            if (temp == '(')
                brackets++;
            if (temp == ')')
                brackets--;

            if (temp == '^' || temp == ')' || temp == '.' || temp == '*' || temp == '/')
            {
                Console.WriteLine("Wrong expression \" (!){0} \"!  ", temp);
                exit_Flag = true;
                return;
            }

            if (temp == '\n' || (temp != '-' && temp != '+' && temp != '(' && (temp < '0' || temp > '9')))
            {
                Console.WriteLine("Unknown characteer \" {0} \" !  ", temp);
                exit_Flag = true;
                return;
            }

            while (Expression[pos] != '\n')
            {
                while (Expression[pos] == ' ')
                    pos++;
                cur = Expression[pos];
                pos++;

                if(brackets < 0)
                {
                    Console.WriteLine("Wrong bracket expression!");
                    exit_Flag = true;
                    return;
                }

                if (cur == '(')
                    brackets++;
                if (cur == ')')
                    brackets--;

                if (cur == '\n')
                {
                    if (temp == '*' || temp == '/')
                    {
                        Console.WriteLine("Missing value \" {0}(!) \"!  ", temp);
                        exit_Flag = true;
                    }
                    break;
                }

                if (cur != '.' && cur != ')' && cur != '/' && cur != '*' && cur != '^' && cur != '-' && cur != '+' && cur != '(' && (cur < '0' || cur > '9'))
                {
                    Console.WriteLine("Unknown characteer \" {0}{1} \"!  ", temp, cur);
                    exit_Flag = true;
                    return;
                }

                if (temp >= '0' && temp <= '9' && cur >= '0' && cur <= '9' && Expression[pos - 2] == ' ')
                {
                    Console.WriteLine("Missing operator \" {0}  {1} \"!  ", temp, cur);
                    exit_Flag = true;
                    return;
                }

                if((cur >= '0' && cur <= '9' && temp == ')') || (temp >= '0' && temp <= '9' && cur == '('))
                {
                    Console.WriteLine("Missing operator \" {0} (!) {1} \"!  ", temp, cur);
                    exit_Flag = true;
                    return;
                }

                if (((cur == '*' || cur == '/' || cur == '^' || cur == ')' || cur == '.' || cur == '+') && (temp == '+' || temp == '.' || temp == '*' || temp == '/' || temp == '^' || temp == '(')) || ((cur == '-' || cur == '+') && (temp == '-' || temp == '+')))
                {
                    Console.WriteLine("Wrong expression \" {0}{1} \"!  ", temp, cur);
                    exit_Flag = true;
                    return;
                }

                if (cur == '^' && Expression[pos - 2] == ' ')
                {
                    Console.WriteLine("Misiing value \" (!){0} \"!  ", cur);
                    exit_Flag = true;
                    return;
                }

                if (cur == '.' && (Expression[pos] == ' ' || Expression[pos - 2] == ' '))
                {
                    Console.WriteLine("Wrong expression \" {0}{1}{2} \"!  ", Expression[pos - 2], cur, Expression[pos]);
                    exit_Flag = true;
                    return;
                }

                temp = cur;
            }

            if(brackets != 0)
            {
                Console.WriteLine("Wrong bracket expression!");
                exit_Flag = true;
            }

            return;
        }
        static char GetNext(string Expression, ref int pos)
        {
            char cur = Expression[pos];
            pos++;

            while (cur == ' ')
            {
                cur = Expression[pos];
                pos++;
            }

            return cur;
        }
        static double GetNumber(string Expression, ref int pos, ref bool exit_flag)
        {
            double ans = 0;
            int sign = 1;
            char cur;

            cur = GetNext(Expression, ref pos);

            if (cur == '-')
                sign = -1;
            else
                pos--;

            while (true)
            {
                cur = GetNext(Expression, ref pos);

                if (cur >= '0' && cur <= '9')
                    ans = ans * 10 + cur - '0';
                else
                {
                    pos--;
                    break;
                }
            }

            cur = GetNext(Expression, ref pos);
            double k = 10;

            if (cur == '.')
            {
                while (true)
                {
                    cur = GetNext(Expression, ref pos);

                    if (cur >= '0' && cur <= '9')
                    {
                        ans += (cur - '0') / k;
                        k *= 10;
                    }
                    else
                    {
                        pos--;
                        break;
                    }
                }
            }
            else
                pos--;

            cur = GetNext(Expression, ref pos);


            if (cur == '^')
            {
                double temp = OpenBrackets(Expression, ref pos, ref exit_flag);

                if (exit_flag == true)
                    return 0;

                return sign * Math.Pow(ans, temp);
            }
            else
                pos--;

            return sign * ans;
        }
        static double Solve(string Expression, ref int pos, ref bool exit_flag)
        {
            double ans = Factor(Expression, ref pos, ref exit_flag);

            if (exit_flag == true)
                return 0;

            char cur;

            while (true)
            {
                cur = GetNext(Expression, ref pos);

                switch (cur)
                {
                    case '+':
                        ans += Factor(Expression, ref pos, ref exit_flag);

                        if (exit_flag == true)
                            return 0;

                        break;
                    case '-':
                        ans -= Factor(Expression, ref pos, ref exit_flag);

                        if (exit_flag == true)
                            return 0;

                        break;
                    default:
                        pos--;
                        return ans;
                }
            }
        }
        static double Factor(string Expression, ref int pos, ref bool exit_flag)
        {
            double ans = OpenBrackets(Expression, ref pos, ref exit_flag);
            char cur;

            if (exit_flag == true)
                return 0;

            while(true)
            {
                cur = GetNext(Expression, ref pos);

                switch (cur)
                {
                    case '*':
                        ans *= OpenBrackets(Expression, ref pos, ref exit_flag);

                        if (exit_flag == true)
                            return 0;

                        break;
                    case '/':
                        double temp = OpenBrackets(Expression, ref pos, ref exit_flag);

                        if (exit_flag == true)
                            return 0;

                        if (temp == 0.0)
                        {
                            Console.WriteLine("Division by zero!");
                            exit_flag = true;
                            return 0;
                        }

                        ans /= temp;
                        break;
                    default:
                        pos--;
                        return ans;
                }
            }
        }
        static double OpenBrackets(string Expression, ref int pos, ref bool exit_flag)
        {
            double ans;
            int sign = 1;
            char cur;

            cur = GetNext(Expression, ref pos);

            if (cur == '-')
            {
                sign = -1;
                cur = GetNext(Expression, ref pos);
            }

            if(cur == '(')
            {
                ans = Solve(Expression, ref pos, ref exit_flag);

                if (exit_flag == true)
                    return 0;

                cur = GetNext(Expression, ref pos);

                if (cur != ')')
                {
                    Console.WriteLine("Wrong bracket expression!");
                    exit_flag = true;
                    return 0;
                }

                cur = GetNext(Expression, ref pos);

                if (cur == '^')
                {
                    double temp = OpenBrackets(Expression, ref pos, ref exit_flag);

                    if (exit_flag == true)
                        return 0;

                    if (temp != (int)temp && ans < 0)
                    {
                        Console.WriteLine("Negativ value in fractional power");
                        exit_flag = true;
                        return 0;
                    }
                    return sign * Math.Pow(ans, temp);
                }
                else
                    pos--;

                return sign * ans;
            }
            else
            {
                pos--;
                return sign * GetNumber(Expression, ref pos, ref exit_flag);
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                bool flag = false;
                int position = 0;
                double ans = 0;

                Console.Write("Enter expression : ");
                string Expression = Console.ReadLine();
                Expression += " \n";

                CheckExpression(Expression, ref flag);
                
                if(!flag)
                    ans = Solve(Expression, ref position, ref flag);

                if(!flag)
                {
                    Console.WriteLine(ans);
                    break;
                }
            }
        }
    }
}
