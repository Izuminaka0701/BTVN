class Monhoc 
{
    string tenmonhoc;
    List<double> diemso;
    public Monhoc(string tenmonhoc)
    {
       this.tenmonhoc = tenmonhoc;
       this.diemso = new List<double>();
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
        double max = diemso[0];
        foreach (int i in diemso)
        {
            if (i > max)
                max = i;
        }
        return max;
    }
    public double Min()
    {
        double min = diemso[0];
        foreach (int i in diemso)
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
        List<Monhoc> monhocs = new List<Monhoc>();
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
