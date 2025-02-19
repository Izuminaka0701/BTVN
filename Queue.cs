using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class HTMLValidatorWithQueue
{
    static bool CheckHTMLValidity(string filePath)
    {
        Console.OutputEncoding = Encoding.UTF8;
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File không tồn tại!");
            return false;
        }

        string htmlContent = File.ReadAllText(filePath);
        Queue<string> queue = new Queue<string>();

        // Biểu thức chính quy để tìm các thẻ HTML
        Regex tagRegex = new Regex(@"</?([a-zA-Z0-9]+)[^>]*>");
        MatchCollection matches = tagRegex.Matches(htmlContent);

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;

            if (match.Value.StartsWith("</")) // Nếu là thẻ đóng
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine($"Lỗi: Thẻ đóng </{tag}> không có thẻ mở tương ứng.");
                    return false;
                }

                string openTag = queue.Dequeue(); // Lấy thẻ mở đầu tiên ra khỏi hàng đợi
                if (openTag != tag)
                {
                    Console.WriteLine($"Lỗi: Thẻ mở <{openTag}> không khớp với thẻ đóng </{tag}>.");
                    return false;
                }
            }
            else if (!match.Value.EndsWith("/>")) // Nếu là thẻ mở (loại bỏ thẻ tự đóng như <br/>)
            {
                queue.Enqueue(tag);
            }
        }

        if (queue.Count > 0)
        {
            Console.WriteLine("Lỗi: Còn thẻ mở chưa đóng: " + string.Join(", ", queue));
            return false;
        }

        return true;
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Nhập đường dẫn file HTML: ");
        string filePath = Console.ReadLine();

        bool isValid = CheckHTMLValidity(filePath);
        Console.WriteLine(isValid ? "HTML hợp lệ!" : "HTML có lỗi!");
    }
}
