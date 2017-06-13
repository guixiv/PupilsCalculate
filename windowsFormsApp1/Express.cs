using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Express
    {
        static int number;
        static string expression;
        static double answer;
        static Dictionary<char, int> priorities = null;
        const string operators = "+-*/%^";
        static Random ran = new Random();

        static Express()
        {
            number = 0;
            priorities = new Dictionary<char, int>();
            priorities.Add('#', -1);
            priorities.Add('+', 0);
            priorities.Add('-', 0);
            priorities.Add('*', 1);
            priorities.Add('/', 1);
        }

        static private int RandomNumber()
        {
            int number = ran.Next(11);
            return number;
        }

        static public char RandomOperator()
        {
            int ope = ran.Next(4);
            char operation;
            switch (ope)
            {
                case 0: operation = '+'; break;
                case 1: operation = '-'; break;
                case 2: operation = '*'; break;
                case 3: operation = '/'; break;
                default: operation = '/'; break;
            }
            return operation;
        }

        static public string RandomExpression()
        {
            expression = "";
            int num,k1,k2;
            char ope='+';
            k1 = ran.Next(1, 3);
            k2 = ran.Next(k1, 3);
            for (int i = 1; i <= 3; )
            {
                if (k1 == i) expression += '(';
                num = RandomNumber();
                if (ope == '/' && num == 0) num = ran.Next(1, 9);
                expression += num;
                i--;
                if (k2 == i) expression += ')';
                i+=2;
                ope = RandomOperator();
                expression += ope;
            }
            expression += RandomNumber();
            if (k2 == 3) expression += ')';
            number++;
            return expression;
        }

          

            static double Compute(double leftNum, double rightNum, char op)
            {
                switch (op)
                {
                    case '+': return leftNum + rightNum;
                    case '-': return leftNum - rightNum;
                    case '*': return leftNum * rightNum;
                    case '/': return leftNum / rightNum;
                    default: return 0;
                }
            }

            static bool IsOperator(char op)
            {
                return operators.IndexOf(op) >= 0;
            }

            static bool IsLeftAssoc(char op)
            {
                return op == '+' || op == '-' || op == '*' || op == '/';
            }

            static Queue<object> PreOrderToPostOrder(string expression)
            {
                var result = new Queue<object>();
                var operatorStack = new Stack<char>();
                operatorStack.Push('#');
                char top, cur, tempChar;
                string tempNum;
                if (expression[0] == '-') expression = '0' + expression;

                for (int i = 0, j; i < expression.Length;)
                {
                    cur = expression[i++];
                    top = operatorStack.Peek();

                    if (cur == '(')
                    {
                        operatorStack.Push(cur);
                    }
                    else
                    {
                        if (IsOperator(cur))
                        {
                            while (IsOperator(top) && ((IsLeftAssoc(cur) && priorities[cur] <= priorities[top])) || (!IsLeftAssoc(cur) && priorities[cur] < priorities[top]))
                            {
                                result.Enqueue(operatorStack.Pop());
                                top = operatorStack.Peek();
                            }
                            operatorStack.Push(cur);
                        }
                        else if (cur == ')')
                        {
                            while (operatorStack.Count > 0 && (tempChar = operatorStack.Pop()) != '(')
                            {
                                result.Enqueue(tempChar);
                            }
                        }
                        else
                        {
                            tempNum = "" + cur;
                            j = i;
                            while (j < expression.Length && (expression[j] == '.' || (expression[j] >= '0' && expression[j] <= '9')))
                            {
                                tempNum += expression[j++];
                            }
                            i = j;
                            result.Enqueue(tempNum);
                        }
                    }
                }
                while (operatorStack.Count > 0)
                {
                    cur = operatorStack.Pop();
                    if (cur == '#') continue;
                    if (operatorStack.Count > 0)
                    {
                        top = operatorStack.Peek();
                    }

                    result.Enqueue(cur);
                }

                return result;
            }

            static double Calucate(string expression)
            {

                var rpn = PreOrderToPostOrder(expression);
                var operandStack = new Stack<double>();
                double left, right;
                object cur;
                while (rpn.Count > 0)
                {
                    cur = rpn.Dequeue();
                    if (cur is char)
                    {
                        right = operandStack.Pop();
                        left = operandStack.Pop();
                        operandStack.Push(Compute(left, right, (char)cur));
                    }
                    else
                    {
                        operandStack.Push(double.Parse(cur.ToString()));
                    }
                }
                return operandStack.Pop();
            }
            static public string show()
            {
                RandomExpression();
                answer = Calucate(expression);
                 return expression;
            }
            static public double showans()
            {
                 return answer;
             }
            static public int shownum()
        {
            return number;
        }

        }
    }
