using System;
using System.Collections.Generic;
using System.Text;

public class TrashBag
{
    public string id;
    public char type;
    public int weight;
    public bool istoxic;

    public void ParseFromId(string id)
    {
        this.id = id;
        this.type = id[0];
        this.weight = int.Parse(id.Substring(1, 6));
        this.istoxic = id[7] == 'X';
    }
}

public class Program
{
    // Tạo danh sách các túi rác từ danh sách mã
    public static List<TrashBag> CreateListOfTrashBags(List<string> ids)
    {
        List<TrashBag> bags = new List<TrashBag>();
        foreach (var id in ids)
        {
            TrashBag bag = new TrashBag();
            bag.ParseFromId(id);
            bags.Add(bag);
        }
        return bags;
    }

    // Sắp xếp danh sách túi rác theo trọng lượng bằng thuật toán sắp xếp nổi bọt
    public static void SortTrashBags(List<TrashBag> bags)
    {
        bags.Sort((a, b) => a.weight.CompareTo(b.weight));
    }

    // Tìm kiếm nhị phân theo trọng lượng
    public static int BinSearchByWeight(List<TrashBag> bags, int weight)
    {
        int left = 0, right = bags.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (bags[mid].weight == weight)
                return mid; // Trả về vị trí tìm thấy
            else if (bags[mid].weight < weight)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1; // Không tìm thấy
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<string> ids = new List<string> { "A000150X", "B000200O", "C000100X", "A000250O", "B000180X" };
        List<TrashBag> bags = CreateListOfTrashBags(ids);

        Console.WriteLine("Danh sách trước khi sắp xếp:");
        foreach (var bag in bags)
            Console.WriteLine($"{bag.id} - Trọng lượng: {bag.weight}");

        SortTrashBags(bags);

        Console.WriteLine("\nDanh sách sau khi sắp xếp:");
        foreach (var bag in bags)
            Console.WriteLine($"{bag.id} - Trọng lượng: {bag.weight}");

        Console.Write("Nhập khối lượng loại rác cần tìm");
        int searchWeight = int.Parse(Console.ReadLine());
        int index = BinSearchByWeight(bags, searchWeight);

        if (index != -1)
            Console.WriteLine($"\nTìm thấy túi rác có trọng lượng {searchWeight} tại vị trí {index}, ID: {bags[index].id}");
        else
            Console.WriteLine($"\nKhông tìm thấy túi rác có trọng lượng {searchWeight}");
    }
}
