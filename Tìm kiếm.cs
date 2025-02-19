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
public class Program
{
    static int SeqSearch(int[] arr, int value)
    {
        int i = 0;
        while (arr[i] != value)
            i++;
        return i;
    }
    static int RecuSearch(int[] arr, int from, int value)
    {
        if (arr == null)
            return -1;
        if (arr[from] == value)
            return from;
        else
            return RecuSearch(arr, from + 1, value);
    }

    //Bài tập 1: Cài đặt SenSearch bằng đệ quy
    static int SensearchRecursion(int[] arr, int value, int from)
    {
        if (from >= arr.Length) 
            return -1;
        if (arr[from] == value) 
            return from;
        return SensearchRecursion(arr, value, from + 1);
    }
    static int SenSearch(int[] arr, int value)
    {
        int x = arr[arr.Length - 1];
        arr[arr.Length - 1] = value; //Thêm phần tử cần tìm vào cuối mang - sentinel
        int i = SeqSearch(arr, value);
        arr[arr.Length - 1] = x;
        if (i < arr.Length - 1)
            return i;
        else if (x == value)
            return arr.Length - 1;
        else
            return -1;
    }

    //Bài tập 2: Cài đặt BinSearch bằng đệ quy
    static int BinsearchRecursion(int[] arr, int L, int R, int value)
    {
        if (L > R) return -1;
        int M = (L + R) / 2;
        if (arr[M] == value) return M;
        if (arr[M] >  value) return BinsearchRecursion(arr, L, M - 1, value);
        return BinsearchRecursion(arr, M + 1, R, value);
    }
    static int BinSearch(int[] sarr, int value)
    {
        int L = 0, R = sarr.Length - 1;
        while (L <= R)
        {
            int m = (L + R) / 2;
            if (sarr[m] == value)
                return m;
            else if (sarr[m] < value)
                L = m + 1;
            else
                R = m - 1;
        }
        return -1;
    }
    public static void Main(string[] args)
    {
        Console.Clear();
        Timing time = new Timing();
        time.startTime();
        //int[] arr = {3, 9, 2, 5, 6};
        //int value = 6;
        //int index = SeqSearch(arr, value);
        //int index = RecuSearch(arr, 0, value);
        //int index = SenSearch(arr, value);
        //Console.WriteLine($"Phần tử có giá trị {value} ở vị trí {index}");
        int[] sarr = { 2, 3, 5, 6, 9 };
        int l = 0;
        int r = sarr.Length;
        int value = 6;
        int index = BinsearchRecursion(sarr, l, r, value);
        Console.WriteLine($"Phần tử có giá trị {value} ở vị trí {index}");
        time.StopTime();
        Console.WriteLine(time.Result().TotalNanoseconds);
        /*int index = SensearchRecursion(arr, value, 1);
        Console.WriteLine($"Phần tử có giá trị {value} ở vị trí {index}");*/
    }
}
