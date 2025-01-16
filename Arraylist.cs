class Monhoc 
{
    string tenmonhoc;
    ArrayList diemso;
    public Monhoc(string tenmonhoc)
    {
       this.tenmonhoc = tenmonhoc;
       this.diemso = new ArrayList();
    }
    public void Nhap()
    {
        Console.WriteLine($"Nhap diem mon: {tenmonhoc}");
        Console.WriteLine("Nhap so luong hs: ");
        int soluonghs = int.Parse(Console.ReadLine());
        for (int i = 0; i < soluonghs ; i++)
        {
            Console.WriteLine($"Nhap diem cho hs {i + 1}: ");
            double diem = double.Parse(Console.ReadLine());
            diemso.Add(diem);
        }
    }
    public double diemtb()
    {
        double sum = 0;
        foreach (double i in diemso)
        {
            sum += i;
        }
        return sum / diemso.Count;
    }
    public double Max()
    {
        double max = (double)diemso[0];
        foreach (double i in diemso)
        {
            if (i > max)
                max = i;
        }
        return max;
    }
    public double Min()
    {
        double min = (double)diemso[0];
        foreach (double i in diemso)
        {
            if (i < min)
                min = i;
        }
        return min;
    }
    public void thongtin()
    {
        Console.WriteLine($"Mon: {tenmonhoc}");
        Console.WriteLine($"Diem tb: {diemtb()}");
        Console.WriteLine($"Diem cao nhat: {Max()}");
        Console.WriteLine($"Diem thap nhat: {Min()}");
    }
}
class Program {
    static void Main()
    {
        Console.Write("Nhap so mon hoc:");
        int somon = int.Parse(Console.ReadLine());
        ArrayList monhocs = new ArrayList();
        for (int i = 0; i < somon; i++)
        {
            Console.WriteLine("Nhap mon: ");
            string tenmonhoc = Console.ReadLine();
            Monhoc monhoc = new Monhoc(tenmonhoc);
            monhoc.Nhap();
            monhocs.Add(monhoc);
        }
        foreach  (Monhoc i in monhocs)
        {
            i.thongtin();
            Console.WriteLine("\n");
        }  
    }
    
}
