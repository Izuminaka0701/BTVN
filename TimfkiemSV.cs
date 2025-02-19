using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Data;
using System.Collections;

namespace BTVN
{
    public class Timing
    {
        TimeSpan startingTime;
        TimeSpan duration;
        public Timing()
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void StopTime()
        {
            duration =
            Process.GetCurrentProcess().Threads[0].
            UserProcessorTime.
            Subtract(startingTime);
        }
        public void startTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime =
            Process.GetCurrentProcess().Threads[0].
            UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    class Sinhvien
    {
        public int Id { get; set; }
        public string Hoten { get; set; }
        public double DiemTB { get; set; }
        public Sinhvien(int id, string hoten, double tb)
        {
            Id = id;
            Hoten = hoten;
            DiemTB = tb;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Ho ten: {Hoten}, Diem TB: {DiemTB}";
        }
    }
    class Program {
        static Sinhvien Seqsearch(List<Sinhvien> danhsach, int id)
        {
            foreach (var i in danhsach)
            {
                if (i.Id == id) return i;
            }
            return null;
        }
        static Sinhvien Binsearch(List<Sinhvien> danhsach, int id)
        {
            danhsach.Sort((a, b) => a.Id.CompareTo(b.Id));
            int L = 0, R = danhsach.Count();
            while (L <= R)
            {
                int M = (L + R) / 2;
                if (danhsach[M].Id == id) return danhsach[M];
                if (danhsach[M].Id > id) R = M - 1;
                else L = M + 1;
            }
            return null;
        }
        static Sinhvien Sensearch(List<Sinhvien> danhsach, int id)
        {
            Sinhvien linhcanh = danhsach[danhsach.Count - 1];
            if (linhcanh.Id == id) return linhcanh;
            danhsach[danhsach.Count - 1] = new Sinhvien(id, "", 0);
            int i = 0;
            while (danhsach[i].Id != id) i++;
            danhsach[danhsach.Count - 1] = linhcanh;

            return (i < danhsach.Count - 1 || linhcanh.Id == id) ? danhsach[i] :null;
        }
        static void Main()
        {
            List<Sinhvien> danhSach = new List<Sinhvien>
        {
            new Sinhvien(102, "Nguyen Van A", 8.5),
            new Sinhvien(101, "Tran Thi B", 7.2),
            new Sinhvien(103, "Le Van C", 9.0)
        };

            int searchId = 102;
            Sinhvien sv2 = Seqsearch(danhSach, searchId);
            Console.WriteLine(sv2 != null ? sv2.ToString() : "Không tìm thấy!");
        }
        
    }
}
