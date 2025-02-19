using System;
using System.Collections.Generic;

class Program
{
    static int EvaluatePostfix(string expression)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Stack<int> stack = new Stack<int>(); // Tạo stack để lưu toán hạng

        foreach (string token in expression.Split(' '))
        {
            if (int.TryParse(token, out int number)) // Nếu là số, push vào stack
            {
                stack.Push(number);
            }
            else // Nếu là toán tử, lấy hai toán hạng từ stack để tính toán
            {
                int b = stack.Pop();
                int a = stack.Pop();
                int result = token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => throw new InvalidOperationException("Toán tử không hợp lệ")
                };
                stack.Push(result); // Push kết quả vào lại stack
            }
        }
        return stack.Pop(); // Phần tử cuối cùng là kết quả
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string postfixExpression = "5 3 + 2 * 4 -"; // Biểu thức hậu tố cần tính
        Console.WriteLine($"Kết quả: {EvaluatePostfix(postfixExpression)}"); // Output: 12
    }
}
