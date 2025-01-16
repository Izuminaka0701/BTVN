class Monhoc 
{
    string tenmonhoc;
    double[] diemso;
    int soluonghs;
    public Monhoc(string tenmonhoc, int soluonghs)
    {
       this.tenmonhoc = tenmonhoc;
       this.soluonghs = soluonghs;
       this.diemso = new double[soluonghs];
    }
    public void Nhap()
    {
        Console.WriteLine($"Nhap diem mon: {tenmonhoc}");
        Console.WriteLine("Nhap so luong hs: ");
        int soluonghs = int.Parse(Console.ReadLine());
        for (int i = 0; i < soluonghs ; i++)
        {
            Console.WriteLine($"Nhap diem cho hs {i + 1}: ");
            diemso[i] = double.Parse(Console.ReadLine());
        }
    }
    public double diemtb()
    {
        double sum = 0;
        foreach (double i in diemso)
        {
            sum += i;
        }
        return sum / soluonghs;
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
        Console.Write("Nhap mon:");
        string tenmonhoc = Console.ReadLine();
        Monhoc monhoc = new Monhoc(tenmonhoc, soluonghs);
        monhoc.Nhap();
        monhoc.thongtin();
    }
    
}
