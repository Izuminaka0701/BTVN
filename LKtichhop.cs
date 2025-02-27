using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        LinkedList<string> names = new LinkedList<string>();
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Thêm phần tử vào danh sách:");
        names.AddFirst("Alice");  
        names.AddLast("Charlie"); 
        names.AddLast("David");  
        names.AddFirst("Bob");    

        LinkedListNode<string> node = names.Find("Charlie");
        if (node != null)
        {
            names.AddAfter(node, "Eve");  
        }

        names.AddBefore(node, "Frank");  

        Console.WriteLine("Danh sách sau khi thêm:");
        PrintLinkedList(names);

        Console.WriteLine("\nXóa phần tử khỏi danh sách:");
        names.RemoveFirst();  
        names.RemoveLast();   
        names.Remove("Frank"); 

        Console.WriteLine("Danh sách sau khi xóa:");
        PrintLinkedList(names);

        Console.WriteLine("\nTìm kiếm phần tử trong danh sách:");
        LinkedListNode<string> foundNode = names.Find("Charlie");
        if (foundNode != null)
        {
            Console.WriteLine("Tìm thấy: " + foundNode.Value);
        }
        else
        {
            Console.WriteLine("Không tìm thấy.");
        }

        Console.WriteLine("\nDuyệt danh sách từ đầu đến cuối:");
        PrintLinkedList(names);

        Console.WriteLine("\nDuyệt danh sách từ cuối về đầu:");
        PrintLinkedListReverse(names);
    }

    private static void PrintLinkedList(LinkedList<string> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    private static void PrintLinkedListReverse(LinkedList<string> list)
    {
        LinkedListNode<string> current = list.Last;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Previous;
        }
    }
}
