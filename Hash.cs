using System.Collections;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

public class Book
{
    public string title;
    public string author;
    public long price;
    public Book(string title, string authors, long price)
    {
        this.title = title;
        this.author = authors;
        this.price = price;
    }
}
public class Books : DictionaryBase
{
    public void Add(string key, Book value)
    {
        base.InnerHashtable.Add(key, value);
    }
    public void Remove(string key)
    {
        base.InnerHashtable.Remove(key);
    }
    public Book Items(string key)
    {
        return (Book)base.InnerHashtable[key];
    }
    public void PrintListofBook()
    {
        Console.WriteLine("{0,10}{1,30}{2,30}{3,30}", "ISBN", "Tiltle", "Authors", "Price");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        foreach(DictionaryEntry entry in base.InnerHashtable)
        {
            Book book = (Book)entry.Value;
            Console.WriteLine("{0,10}{1,30}{2,30}{3,30}", entry.Key, book.title, book.author, book.price);
        }
    }
    public Book FindBook(string key)
    {
        foreach (DictionaryEntry entry in base.InnerHashtable)
        {
            Book book  = (Book)entry.Value;
            if (book.title.Contains(key))
            {
                return book;
            }
        }
        return null;
    }
    public void UpdateBook(string key, string title, string authors, long price)
    {
        Book book =(Book)base.InnerHashtable[key];
        book.title =title;
        book.author =authors;
        book.price =price;

    }
}
class Books2
{
    private Dictionary<string, Book> bookDict = new Dictionary<string, Book>();

    public void Add(string key, Book book)
    {
        string hashedKey = ComputeMD5Hash(key);
        bookDict[hashedKey] = book;
    }
    public void PrintListoBook()
    {
        foreach (var entry in bookDict)
        {
            Console.WriteLine("[{0}] {1}, {2}, {3}", entry.Key, entry.Value.title, entry.Value.author, entry.Value.price);
        }
    }
    public Book FindBook(string keyword)
    {
        foreach (var entry in bookDict)
        {
            if (entry.Value.title.Contains(keyword))
                return entry.Value;
        }
        return null;
    }
    public void UpdateBook(string key, string newTitle, string newAuthor, int newPrice)
    {
        string hashedKey = ComputeMD5Hash(key);
        if (bookDict.ContainsKey(hashedKey))
        {
            bookDict[hashedKey] = new Book(newTitle, newAuthor, newPrice);
        }
    }

    private string ComputeMD5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

}
public class Program
{

    public static void Main(string[] args)
    {
        bai4();

    }
    static void bai1()
    {
        Console.Clear();
        Book book1 = new Book("C# programming", "John Doe", 100);
        Book book2 = new Book("C programming", "Minh", 200);
        Book book3 = new Book("Python programing", "Quan", 300);
        Books bookdict = new Books();
        bookdict.Add("ISBN01", book1);
        bookdict.Add("ISBN02", book2);
        bookdict.Add("ISBN03", book3);
        bookdict.PrintListofBook();
        string keyword = "C";
        Book book = bookdict.FindBook(keyword);
        if (book != null)
        {
            Console.WriteLine("Book found with[{0}]:{0},{1},{2}", book.title, book.author, book.price);
        }
        bookdict.UpdateBook("ISBN03", "Python programing", "Minh Quan", 3444);
        bookdict.PrintListofBook();

        //Console.WriteLine("Tiltle: {0}",bookdict.Items("ISBN01").title);
        //bookdict.Remove("ISBN02");
    }
    static void bai2()
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        string filePath = "std.txt";
        if (File.Exists(filePath))
        {
            foreach(var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if(parts.Length == 2)
                {
                    phoneBook[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
        Console.WriteLine("Nhap ten de tim so dien thoai: ");
        string name =Console.ReadLine();
        if (phoneBook.ContainsKey(name))
        {
            Console.WriteLine($"so dien thoai cua{name}: {phoneBook[name]}");
        }
        else
        {
            Console.WriteLine(" ko tim thay sdt nao trong danh ba");
        }
        Console.Write("Nhap so dien thoai de tim ten: ");
        string phoneNumber = Console.ReadLine();
        bool found =false;
        foreach (var entry in phoneBook)
        {
            if (entry.Value == phoneNumber)
            {
                Console.WriteLine($"so dien thoai {phoneNumber} thuoc ve: {entry.Key}");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("ko tim thay so dien thoai nao trong danh ba.");
        }
    }
    static void bai3()
    {
        Hashtable dictionary = new Hashtable();
        string file = "file.txt";
        if (File.Exists(file))
        {
            foreach (var word in File.ReadAllLines(file))
            {
                dictionary[word.Trim()] = true;
            }
        }
        else
        {
            Console.WriteLine("Nhap noi dung kiem tra chinh ta: ");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            foreach (var word in words)
            {
                string trimeWord =word.Trim().ToLower();
                if(!dictionary.ContainsKey(trimeWord))
                {
                    Console.WriteLine($"Tu {word} co the bi sai chinh ta ");
                }
            }
        }

    }
    static void bai4()
    {
        Console.Clear();
        Book book1 = new Book("C# programming", "John Doe", 100);
        Book book2 = new Book("C programming", "Minh", 200);
        Book book3 = new Book("Python programming", "Quan", 300);
        Books bookdict = new Books();
        bookdict.Add("ISBN01", book1);
        bookdict.Add("ISBN02", book2);
        bookdict.Add("ISBN03", book3);
        bookdict.PrintListofBook();

        string keyword = "C";
        Book book = bookdict.FindBook(keyword);
        if (book != null)
        {
            Console.WriteLine("Book found: {0}, {1}, {2}", book.title, book.author, book.price);
        }

        bookdict.UpdateBook("ISBN03", "Python programming", "Minh Quan", 3444);
        bookdict.PrintListofBook();
    }
}
