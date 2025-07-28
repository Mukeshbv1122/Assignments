using System;
using System.Linq;
class Operations
{
    public static int Sum(params int?[] n) => n.Sum(x => x ?? 10);
    public static int Sub(int? a, int? b) => (a ?? 10) - (b ?? 10);
    public static int Product(params int?[] n) => n.Aggregate(1, (p, x) => p * (x ?? 10));
    public static int Min(params int?[] n) => n.Min(x => x ?? 10);
    public static int Max(params int?[] n) => n.Max(x => x ?? 10);
    public static bool IsEven(int? n) => (n ?? 10) % 2 == 0;
    public static bool IsOdd(int? n) => (n ?? 10) % 2 != 0;
    public static bool IsPrime(int? n)
    {
        int num = n ?? 10;
        if (num < 2) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
            if (num % i == 0) return false;
        return true;
    }
}
class NumberExtensions
{
    public static void ShowEven(int s, int e) => PrintRange(s, e, i => i % 2 == 0);
    public static void ShowOdd(int s, int e) => PrintRange(s, e, i => i % 2 != 0);
    public static void ShowPrime(int s, int e) => PrintRange(s, e, i => Operations.IsPrime(i));
    public static void Table(int n) { for (int i = 1; i <= 10; i++) Console.WriteLine($"{n} x {i} = {n * i}"); }
    public static int Reverse(int n) { int r = 0; while (n > 0) { r = r * 10 + n % 10; n /= 10; } return r; }
    static void PrintRange(int s, int e, Func<int, bool> f) { for (int i = s; i <= e; i++) if (f(i)) Console.Write(i + " "); Console.WriteLine(); }
}
class StringExtensions
{
    public static int CountChars(string s) => (s ?? "*").Length;
    public static bool IsPalindrome(string s)
    {
        s = (s ?? "*").ToLower().Replace(" ", "");
        return s == new string(s.Reverse().ToArray());
    }
    public static string ReverseStr(string s) => new string((s ?? "*").Reverse().ToArray());
}
class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Math");
            Console.WriteLine("Sum: " + Operations.Sum(1, null, 3));
            Console.WriteLine("Sub: " + Operations.Sub(null, 4));
            Console.WriteLine("Product: " + Operations.Product(2, null, 3));
            Console.WriteLine("Min: " + Operations.Min(5, null, 3));
            Console.WriteLine("Max: " + Operations.Max(5, 20, null));
            Console.WriteLine("IsEven(4): " + Operations.IsEven(4));
            Console.WriteLine("IsOdd(5): " + Operations.IsOdd(5));
            Console.WriteLine("IsPrime(7): " + Operations.IsPrime(7));

            Console.WriteLine("Number Range");
            Console.Write("Even (1-10): "); NumberExtensions.ShowEven(1, 10);
            Console.Write("Odd (1-10): "); NumberExtensions.ShowOdd(1, 10);
            Console.Write("Prime (1-10): "); NumberExtensions.ShowPrime(1, 10);
            Console.WriteLine("Table of 5:"); NumberExtensions.Table(5);
            Console.WriteLine("Reverse 1234: " + NumberExtensions.Reverse(1234));

            Console.WriteLine("Strings");
            string str = "tenet";
            Console.WriteLine("Char Count: " + StringExtensions.CountChars(str));
            Console.WriteLine("Palindrome: " + StringExtensions.IsPalindrome(str));
            Console.WriteLine("Reversed: " + StringExtensions.ReverseStr(str));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}