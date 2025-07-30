using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructureDemos
{
    enum Sort { Bubble = 1, Selection, Shell, Insertion };

    internal class SortingDemos
    {
        static int[] num = new int[] { 12, 23, 34, 11, 35, 11, 9, 5, 6, 3, 1, 10 };

        static void Main()
        {
            DisplayElements();
            Console.WriteLine("Which sorting tech");
            int ch = byte.Parse(Console.ReadLine());
            switch (ch)
            {
                case (int)Sort.Bubble: BubbleSort(); break;
                case (int)Sort.Selection: SelectionSort(); break;
                case (int)Sort.Insertion: InsertionSort(); break;
                case (int)Sort.Shell: ShellSort(); break;
            }
            DisplayElements();
        }

        static void BubbleSort()
        {
            int temp;
            for (int i = 0; i <= num.Length - 2; i++)
            {
                for (int j = 0; j <= num.Length - 2; j++)
                {
                    if (num[j] > num[j + 1])
                    {
                        temp = num[j + 1];
                        num[j + 1] = num[j];
                        num[j] = temp;
                    }
                }
            }
        }

        static void SelectionSort()
        {
            int temp;
            for (int i = 0; i < num.Length - 1; i++)
            {
                for (int j = i + 1; j < num.Length; j++)
                {
                    if (num[i] > num[j])
                    {
                        temp = num[j];
                        num[j] = num[i];
                        num[i] = temp;
                    }
                }
            }
        }
        static void ShellSort()
        {
            int n = num.Length;
            int gap = n / 2;
            int temp;
            while (gap > 0)
            {
                for (int i = 0; i + gap < n; i++)
                {
                    int j = i + gap;
                    temp = num[j];
                    while (j - gap > 0 && temp < num[j - gap])
                    {
                        num[j] = num[j - gap];
                        j = j - gap;
                    }
                    num[j] = temp;
                }
                gap = gap / 2;
            }
        }
        static void InsertionSort()
        {
            for (int i = 1; i < num.Length; i++)
            {
                int temp = num[i];
                int j = i - 1;
                while (j >= 0 && num[j] > temp)
                {
                    num[j + 1] = num[j];
                    j--;
                }
                num[j + 1] = temp;
            }
        }

        static void DisplayElements()
        {
            foreach (int i in num)
            {
                Console.WriteLine(i);
            }
        }
    }
}