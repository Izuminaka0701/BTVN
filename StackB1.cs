using System;
using System.Collections.Generic;

class InfixToPostfix
{
    // Hàm xác định độ ưu tiên của toán tử
    static int Priority(char op)
    {
        if (op == '+' || op == '-') return 1;
        if (op == '*' || op == '/') return 2;
        return 0;
    }

    // Hàm chuyển biểu thức Infix sang Postfix
    static string ConvertToPostfix(string infix)
    {
        Stack<char> stack = new Stack<char>();
        string postfix = "";

        foreach (char ch in infix)
        {
            // Nếu là toán hạng, thêm vào output
            if (char.IsLetterOrDigit(ch))
            {
                postfix += ch;
            }
            // Nếu là dấu '(', push vào stack
            else if (ch == '(')
            {
                stack.Push(ch);
            }
            // Nếu là dấu ')', pop ra đến khi gặp '('
            else if (ch == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    postfix += stack.Pop();
                }
                stack.Pop(); // Loại bỏ '(' khỏi stack
            }
            // Nếu là toán tử (+, -, *, /)
            else
            {
                while (stack.Count > 0 && Priority(stack.Peek()) >= Priority(ch))
                {
                    postfix += stack.Pop();
                }
                stack.Push(ch);
            }
        }

        // Pop các toán tử còn lại trong stack
        while (stack.Count > 0)
        {
            postfix += stack.Pop();
        }

        return postfix;
    }

    // Hàm chính
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Nhập biểu thức Infix: ");
        string infix = Console.ReadLine();
        string postfix = ConvertToPostfix(infix);
        Console.WriteLine("Biểu thức Postfix: " + postfix);
    }
}
