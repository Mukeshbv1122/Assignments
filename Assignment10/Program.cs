using System;
using System.Linq;
static class Operations
{
    public static int Sum(params int?[] nums) => nums.Select(n => n ?? 10).Sum();
    public static int Subtract(int? a, int? b) => (a ?? 10) - (b ?? 10);
    public static int Product(params int?[] nums) => nums.Select(n => n ?? 10).Aggregate(1, (a, b) => a * b);
    public static int Min(params int?[] nums) => nums.Select(n => n ?? 10).Min();
    public static int Max(params int?[] nums) => nums.Select(n => n ?? 10).Max();
    public static bool IsEven(int? n) => (n ?? 10) % 2 == 0;
    public static bool IsOdd(int? n) => (n ?? 10) % 2 != 0;
    public static bool IsPrime(int? n)
    {
        int num = n ?? 10;
        if (num < 2) 
            return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
            if (num % i == 0) 
                return false;
        return true;
    }
}
static class Everything
{
    public static void ShowEven(this int start, int end) { for (int i = start; i <= end; i++) if (i % 2 == 0) Console.Write(i + " "); Console.WriteLine(); }
    public static void ShowOdd(this int start, int end) { for (int i = start; i <= end; i++) if (i % 2 != 0) Console.Write(i + " "); Console.WriteLine(); }
    public static void ShowPrime(this int start, int end) { for (int i = start; i <= end; i++) if (Operations.IsPrime(i)) Console.Write(i + " "); Console.WriteLine(); }
    public static void Table(this int n) { for (int i = 1; i <= 10; i++) Console.WriteLine($"{n} x {i} = {n * i}"); }
    public static void Tables1To10(this int start, int end) { for (int i = start; i <= end; i++) { Console.WriteLine($"\nTable of {i}:"); i.Table(); } }
    public static void TablesInRange(this int start, int end, int from, int to) { for (int i = start; i <= end; i++) { Console.WriteLine($"\nTable of {i}:"); for (int j = from; j <= to; j++) Console.WriteLine($"{i} x {j} = {i * j}"); } }
    public static int Reverse(this int n) { int r = 0; while (n != 0) { r = r * 10 + n % 10; n /= 10; } return r; }
    public static int CharCount(this string s) => (s ?? "*").Length;
    public static bool IsPalindrome(this string s) => (s ?? "*").ToLower().Replace(" ", "") is var str && str == new string(str.Reverse().ToArray());
    public static string ReverseStr(this string s) => new string((s ?? "*").Reverse().ToArray());
    public static void Analyze(this string s)
    {
        s ??= "*"; int vow = 0, con = 0, dig = 0, spl = 0;
        foreach (char ch in s) if ("aeiouAEIOU".Contains(ch)) vow++; else if (char.IsLetter(ch)) con++; else if (char.IsDigit(ch)) dig++; else if (!char.IsWhiteSpace(ch)) spl++;
        Console.WriteLine($"Vowels: {vow}, Consonants: {con}, Digits: {dig}, Specials: {spl}");
    }
    public static string ToProper(this string s) => string.Join(" ", (s ?? "*").Split(' ').Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
    public static string RemoveSpaces(this string s) => string.Join(" ", (s ?? "*").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    public static int WordCount(this string s) => (s ?? "*").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    public static bool HasSubstring(this string s, string sub) => (s ?? "").Contains(sub ?? "");
    public static int CountSubstring(this string s, string sub) => (s ?? "").Split(sub ?? "").Length - 1;
}
class All
{
    static void Main()
    {
        Console.WriteLine("MENU");
        Console.WriteLine("1. Math Operations \n2. Number Extension Methods \n3. String Extensions");
        Console.Write("Choose: ");
        int ch = int.Parse(Console.ReadLine());
        switch (ch)
        {
            case 1:
                Console.WriteLine("Sum(5, null, 15): " + Operations.Sum(5, null, 15));
                Console.WriteLine("Subtract(20, null): " + Operations.Subtract(20, null));
                Console.WriteLine("Product(2, null, 3): " + Operations.Product(2, null, 3));
                Console.WriteLine("Min(2, null, 1): " + Operations.Min(2, null, 1));
                Console.WriteLine("Max(4, null, 7): " + Operations.Max(4, null, 7));
                Console.WriteLine("IsEven(null): " + Operations.IsEven(null));
                Console.WriteLine("IsOdd(5): " + Operations.IsOdd(5));
                Console.WriteLine("IsPrime(13): " + Operations.IsPrime(13));
                break;
            case 2:
                Console.WriteLine("Even numbers (1–10): "); 1.ShowEven(10);
                Console.WriteLine("Odd numbers (1–10): "); 1.ShowOdd(10);
                Console.WriteLine("Prime numbers (1–20): "); 1.ShowPrime(20);
                Console.WriteLine("Table of 5:"); 5.Table();
                Console.WriteLine("Tables 2–3 (1–10):"); 2.Tables1To10(3);
                Console.WriteLine("Tables 2–3 (3–5):"); 2.TablesInRange(3, 3, 5);
                Console.WriteLine("Reverse of 1234: " + 1234.Reverse());
                break;
            case 3:
                string s1 = "Hello, My name is MUKESH", 
                    s2 = "tenet";
                Console.WriteLine("Char count: " + s1.CharCount());
                Console.WriteLine("IsPalindrome(tenet): " + s2.IsPalindrome());
                Console.WriteLine("Reverse: " + s1.ReverseStr());
                Console.Write("Analysis of sentence: "); s1.Analyze();
                Console.WriteLine("ToUpper: " + s1.ToUpper());
                Console.WriteLine("Proper Case: " + "I am in a training session".ToProper());
                Console.WriteLine("Combined: " + s1 + " & " + s2);
                Console.WriteLine("No extra spaces: " + "  too   many        spaces  ".RemoveSpaces());
                Console.WriteLine("Word Count: " + s1.WordCount());
                Console.WriteLine("Contains 'is': " + s1.HasSubstring("is"));
                Console.WriteLine("Occurrences of 'z': " + s1.CountSubstring("z"));
                break;
            default: Console.WriteLine("Invalid choice"); 
                break;
        }
    }
}