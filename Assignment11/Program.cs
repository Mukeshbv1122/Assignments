using System;
using System.Text.RegularExpressions;
namespace Assignment11;
class MyLibrary
{
    public static int Add(params int[] nums)
    {
        int sum = 0;
        foreach (int n in nums) sum += n;
        return sum;
    }
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static float Divide(float a, float b) => b != 0 ? a / b : 0;
    public static int FindMax(params int[] nums)
    {
        int max = nums[0];
        foreach (int n in nums) if (n > max) max = n;
        return max;
    }
    public static int FindMin(params int[] nums)
    {
        int min = nums[0];
        foreach (int n in nums) if (n < min) min = n;
        return min;
    }
    public static bool IsEven(int n) => n % 2 == 0;
    public static bool IsOdd(int n) => n % 2 != 0;
    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }
    public static void DisplayEven(int start, int end)
    {
        for (int i = start; i <= end; i++) if (IsEven(i)) Console.Write(i + " ");
        Console.WriteLine();
    }
    public static void DisplayOdd(int start, int end)
    {
        for (int i = start; i <= end; i++) if (IsOdd(i)) Console.Write(i + " ");
        Console.WriteLine();
    }
    public static void DisplayPrime(int start, int end)
    {
        for (int i = start; i <= end; i++) if (IsPrime(i)) Console.Write(i + " ");
        Console.WriteLine();
    }
    public static void DisplayTable(int n)
    {
        for (int i = 1; i <= 10; i++) Console.WriteLine($"{n} x {i} = {n * i}");
    }
    public static void Tables1to10()
    {
        for (int i = 1; i <= 10; i++) DisplayTable(i);
    }
    public static void TablesInRange(int start, int end)
    {
        for (int i = start; i <= end; i++) DisplayTable(i);
    }
    public static int ReverseNumber(int n)
    {
        int rev = 0;
        while (n > 0)
        {
            rev = rev * 10 + n % 10;
            n /= 10;
        }
        return rev;
    }
    public static int CountChars(string s) => s.Length;
    public static bool IsPalindrome(string s)
    {
        string rev = ReverseSentence(s);
        return s.Replace(" ", "").Equals(rev.Replace(" ", ""), StringComparison.OrdinalIgnoreCase);
    }
    public static string ReverseSentence(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    public static void CountDetails(string s, out int vowels, out int consonants, out int digits, out int specials)
    {
        vowels = consonants = digits = specials = 0;
        foreach (char c in s.ToLower())
        {
            if ("aeiou".Contains(c)) vowels++;
            else if (char.IsLetter(c)) consonants++;
            else if (char.IsDigit(c)) digits++;
            else if (!char.IsWhiteSpace(c)) specials++;
        }
    }
    public static string ToUpperCase(string s) => s.ToUpper();
    public static string ToProperCase(string s)
    {
        string[] words = s.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
        return string.Join(" ", words);
    }
    public static string Combine(string s1, string s2) => s1 + " " + s2;
    public static string RemoveExtraSpaces(string s) => Regex.Replace(s, @"\s+", " ").Trim();
    public static int CountWords(string s) => s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    public static bool SearchSubstring(string s, string sub) => s.Contains(sub, StringComparison.OrdinalIgnoreCase);
    public static int CountOccurrences(string s, string sub)
    {
        int count = 0, index = 0;
        while ((index = s.IndexOf(sub, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += sub.Length;
        }
        return count;
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Add: " + MyLibrary.Add(1, 2, 3, 4));
        Console.WriteLine("Subtract: " + MyLibrary.Subtract(10, 3));
        Console.WriteLine("Multiply: " + MyLibrary.Multiply(4, 5));
        Console.WriteLine("Divide: " + MyLibrary.Divide(10, 2));
        Console.WriteLine("Max: " + MyLibrary.FindMax(3, 8, 1, 9));
        Console.WriteLine("Min: " + MyLibrary.FindMin(3, 8, 1, 9));
        Console.WriteLine("IsEven(4): " + MyLibrary.IsEven(4));
        Console.WriteLine("IsOdd(7): " + MyLibrary.IsOdd(7));
        Console.WriteLine("IsPrime(11): " + MyLibrary.IsPrime(11));
        Console.Write("Even numbers (1-10): "); MyLibrary.DisplayEven(1, 10);
        Console.Write("Odd numbers (1-10): "); MyLibrary.DisplayOdd(1, 10);
        Console.Write("Prime numbers (1-20): "); MyLibrary.DisplayPrime(1, 20);
        Console.WriteLine("Table of 5:");
        MyLibrary.DisplayTable(5);
        Console.WriteLine("Tables from 1 to 10:");
        MyLibrary.Tables1to10();
        Console.WriteLine("Tables in range 2 to 3:");
        MyLibrary.TablesInRange(2, 3);
        Console.WriteLine("Reverse of 1234: " + MyLibrary.ReverseNumber(1234));
        string text = "My name is Mukesh";
        string palindromeText = "tenet";
        string sentence = "   This   is   a   test   sentence!   ";
        Console.WriteLine("Character count: " + MyLibrary.CountChars(text));
        Console.WriteLine("Is Palindrome (tenet): " + MyLibrary.IsPalindrome(palindromeText));
        Console.WriteLine("Reverse of sentence: " + MyLibrary.ReverseSentence(text));
        MyLibrary.CountDetails("Hello123!", out int vowels, out int consonants, out int digits, out int specials);
        Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}, Digits: {digits}, Specials: {specials}");
        Console.WriteLine("To Upper Case: " + MyLibrary.ToUpperCase(text));
        Console.WriteLine("Proper Case: " + MyLibrary.ToProperCase("hello world welcome"));
        Console.WriteLine("Combine: " + MyLibrary.Combine("Hello", "World"));
        Console.WriteLine("Remove Extra Spaces: '" + MyLibrary.RemoveExtraSpaces(sentence) + "'");
        Console.WriteLine("Word Count: " + MyLibrary.CountWords(sentence));
        Console.WriteLine("Search Substring (test): " + MyLibrary.SearchSubstring(sentence, "test"));
        Console.WriteLine("Count Occurrences of 'is': " + MyLibrary.CountOccurrences("This is a test. It is simple.", "is"));
    }
}