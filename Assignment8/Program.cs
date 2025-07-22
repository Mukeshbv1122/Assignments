using System;
using System.Collections;
using System.Text;
class Solution
{
    public int SmallestPositiveSquare(int[] A)
    {
        HashSet<int> positives = new HashSet<int>();
        foreach (int num in A)
            if (num > 0) positives.Add(num);
        if (positives.Count == 0) return 0;
        int min = int.MaxValue;
        foreach (int num in positives)
            if (num < min) min = num;
        return min * min;
    }
    public string MultiplicationTable(int N1, int N2, int Start, int End)
    {
        if (N1 <= 0 || N2 <= 0 || Start <= 0 || End <= 0) return "0";
        if (N1 > N2 || Start > End) return "Invalid range";
        StringBuilder sb = new StringBuilder();
        for (int i = N1; i <= N2; i++)
            for (int j = Start; j <= End; j++)
                sb.AppendLine($"{i} * {j} = {i * j}");
        return sb.ToString();
    }
    public int SumPositiveUntilZero(int[] A)
    {
        int sum = 0;
        foreach (int num in A)
        {
            if (num == 0)
                break;
            if (num > 0) 
                sum += num;
        }
        return sum;
    }
}
class Program
{
    static void Main()
    {
        Solution sol = new Solution();
        while (true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Square of Smallest Positive Integer");
            Console.WriteLine("2. Multiplication Table from N1 to N2 and Start to End");
            Console.WriteLine("3. Sum of Positives Until 0 in Array");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice (1-4): ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Write("Enter array elements: ");
                int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                Console.WriteLine("Result: " + sol.SmallestPositiveSquare(A));
            }
            else if (choice == "2")
            {
                Console.Write("Enter N1: ");
                int N1 = int.Parse(Console.ReadLine());
                Console.Write("Enter N2: ");
                int N2 = int.Parse(Console.ReadLine());
                Console.Write("Enter Start: ");
                int Start = int.Parse(Console.ReadLine());
                Console.Write("Enter End: ");
                int End = int.Parse(Console.ReadLine());
                Console.WriteLine(sol.MultiplicationTable(N1, N2, Start, End));
            }
            else if (choice == "3")
            {
                Console.Write("Enter array elements: ");
                int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                Console.WriteLine("Result: " + sol.SumPositiveUntilZero(A));
            }
            else if (choice == "4")
            {
                Console.WriteLine("Exit Complete");
                break;
            }
            else Console.WriteLine("Invalid choice.");
        }
    }
}
