using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment12
{
    public class NumericFunctions
    {
        public int Add(params int[] numbers) => numbers.Sum();
        public int Subtract(int a, int b) => a - b;
        public int Multiply(params int[] numbers) => numbers.Aggregate(1, (x, y) => x * y);
        public float Divide(float a, float b) => b != 0 ? a / b : throw new DivideByZeroException();
        public int Max(params int[] numbers) => numbers.Max();
        public int Min(params int[] numbers) => numbers.Min();
        public bool IsEven(int number) => number % 2 == 0;
        public bool IsOdd(int number) => number % 2 != 0;
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }
        public List<int> EvenInRange(int start, int end) => Enumerable.Range(start, end - start + 1).Where(x => x % 2 == 0).ToList();
        public List<int> OddInRange(int start, int end) => Enumerable.Range(start, end - start + 1).Where(x => x % 2 != 0).ToList();
        public List<int> PrimesInRange(int start, int end) => Enumerable.Range(start, end - start + 1).Where(IsPrime).ToList();
        public List<string> DisplayTable(int number) => Enumerable.Range(1, 10).Select(i => $"{number} x {i} = {number * i}").ToList();
        public int Reverse(int number)
        {
            int reversed = 0;
            while (number > 0)
            {
                int digit = number % 10;
                reversed = reversed * 10 + digit;
                number /= 10;
            }
            return reversed;
        }
    }

    public class StringFunctions
    {
        public int CharacterCount(string input) => input.Length;
        public bool IsPalindrome(string input)
        {
            string cleaned = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return cleaned == new string(cleaned.Reverse().ToArray());
        }
        public string ReverseSentence(string input) => new string(input.Reverse().ToArray());
        public (int vowels, int consonants, int digits, int specialChars) AnalyzeString(string input)
        {
            int vowels = 0, consonants = 0, digits = 0, special = 0;
            string vowelSet = "aeiou";
            foreach (char c in input.ToLower())
            {
                if (char.IsLetter(c))
                {
                    if (vowelSet.Contains(c)) vowels++;
                    else consonants++;
                }
                else if (char.IsDigit(c)) digits++;
                else if (!char.IsWhiteSpace(c)) special++;
            }
            return (vowels, consonants, digits, special);
        }
        public string ToUpperCase(string input) => input.ToUpper();
        public string ToProperCase(string input) =>
            System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        public string CombineSentences(string s1, string s2) => $"{s1} {s2}".Trim();
        public string RemoveExtraSpaces(string input) => string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        public int WordCount(string input) => input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        public bool ContainsSubstring(string sentence, string word) => sentence.Contains(word, StringComparison.OrdinalIgnoreCase);
        public int SubstringOccurrences(string sentence, string word)
        {
            int count = 0, index = 0;
            while ((index = sentence.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numeric = new NumericFunctions();
            var strFunc = new StringFunctions();

            Console.WriteLine("Choose: 1. Numeric Functions  2. String Functions");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Sum: " + numeric.Add(1, 2, 3, 4));
                Console.WriteLine("Subtract: " + numeric.Subtract(10, 4));
                Console.WriteLine("Multiply: " + numeric.Multiply(2, 3, 4));
                Console.WriteLine("Divide: " + numeric.Divide(10, 2));
                Console.WriteLine("Max: " + numeric.Max(1, 4, 8, 9));
                Console.WriteLine("Min: " + numeric.Min(1, 4, 8, 9));
                Console.WriteLine("Is 6 Even? " + numeric.IsEven(6));
                Console.WriteLine("Is 7 Prime? " + numeric.IsPrime(7));
                Console.WriteLine("Table for 5:");
                numeric.DisplayTable(5).ForEach(Console.WriteLine);
                Console.WriteLine("Reverse of 12345: " + numeric.Reverse(12345));
            }
            else if (choice == 2)
            {
                Console.Write("Enter sentence: ");
                string input = Console.ReadLine() ?? "";
                Console.WriteLine("Character Count: " + strFunc.CharacterCount(input));
                Console.WriteLine("Is Palindrome: " + strFunc.IsPalindrome(input));
                Console.WriteLine("Reversed: " + strFunc.ReverseSentence(input));
                var analysis = strFunc.AnalyzeString(input);
                Console.WriteLine($"Vowels: {analysis.vowels}, Consonants: {analysis.consonants}, Digits: {analysis.digits}, Special: {analysis.specialChars}");
                Console.WriteLine("Uppercase: " + strFunc.ToUpperCase(input));
                Console.WriteLine("Proper Case: " + strFunc.ToProperCase(input));
                Console.WriteLine("Combined with 'Hello World': " + strFunc.CombineSentences(input, "Hello World"));
                Console.WriteLine("Removed Extra Spaces: " + strFunc.RemoveExtraSpaces(input));
                Console.WriteLine("Word Count: " + strFunc.WordCount(input));
                Console.WriteLine("Contains 'test'? " + strFunc.ContainsSubstring(input, "test"));
                Console.WriteLine("Occurrences of 'is': " + strFunc.SubstringOccurrences(input, "is"));
            }
        }
    }
}