using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.task2
{
    internal class QueueDemo
    {
        static int[] num = new int[10];
        static int front = -1, rear = -1;
        static void Main()
        {
            string choice = "y";
            while (choice == "y")
            {
                int ch = GetMenu();
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter element to insert:");
                        int temp = int.Parse(Console.ReadLine());
                        Insert(temp);
                        break;
                    case 2:
                        Delete();
                        break;
                    case 3:
                        Display();
                        break;
                    case 4:
                        choice = "n";
                        continue;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("Repeat? (y/n):");
                choice = Console.ReadLine();
            }
        }
        static int GetMenu()
        {
            Console.WriteLine("QUEUE MENU");
            Console.WriteLine("1. Insert Element");
            Console.WriteLine("2. Delete Element");
            Console.WriteLine("3. Display Elements");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());
        }
        static void Insert(int temp)
        {
            if (rear >= num.Length - 1)
            {
                Console.WriteLine("Queue OVERFLOW: Cannot insert more elements.");
            }
            else if (front == -1 && rear == -1)
            {
                front = rear = 0;
                num[rear] = temp;
                Console.WriteLine("First element inserted.");
            }
            else
            {
                rear++;
                num[rear] = temp;
                Console.WriteLine($"Element inserted at position {rear}.");
            }
        }
        static void Delete()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("Queue UNDERFLOW: No elements to delete.");
            }
            else
            {
                Console.WriteLine($"Deleted element: {num[front]}");
                front++;
                if (front > rear)
                {
                    front = rear = -1;
                }
            }
        }
        static void Display()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("Queue is empty.");
            }
            else
            {
                Console.WriteLine("Queue elements:");
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine(num[i]);
                }
            }
        }
    }
}