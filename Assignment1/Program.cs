using System;

class Assignment1
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== C# Assignment Menu =====");
            Console.WriteLine("1. Display Hello Message");
            Console.WriteLine("2. Perform Arithmetic Operations (Add, Subtract, Multiply, Divide)");
            Console.WriteLine("3. Arithmetic Operations based on choice (if-else / switch)");
            Console.WriteLine("4. Display Your Name 10 Times");
            Console.WriteLine("5. Display All Even Numbers (do-while, while, for loop)");
            Console.WriteLine("6. Display All Odd Numbers (do-while, while, for loop)");
            Console.WriteLine("7. Display Table of a Number (using all loops)");
            Console.WriteLine("8. Display Numbers from 100 to 5 with gap of 3");
            Console.WriteLine("9. Declare Integers and Display in One Line");
            Console.WriteLine("10. Declare Integers and Display in Separate Lines");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hello! Welcome to C# Assignment.");
                    break;

                case 2:
                    ArithmeticAll();
                    break;

                case 3:
                    ArithmeticChoice();
                    break;

                case 4:
                    for (int i = 1; i <= 10; i++)
                        Console.WriteLine("MUKESH");
                    break;

                case 5:
                    EvenNumbersAllLoops();
                    break;

                case 6:
                    OddNumbersAllLoops();
                    break;

                case 7:
                    DisplayTable();
                    break;

                case 8:
                    for (int i = 100; i >= 5; i -= 3)
                        Console.Write(i + " ");
                    Console.WriteLine();
                    break;

                case 9:
                    int a = 10, b = 20, c = 30;
                    Console.WriteLine($"Values: {a}, {b}, {c}");
                    break;

                case 10:
                    int x = 5, y = 15, z = 25;
                    Console.WriteLine($"x = {x}\ny = {y}\nz = {z}");
                    break;

                case 0:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

        } while (choice != 0);
    }

    static void ArithmeticAll()
    {
        Console.Write("Enter first number: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Addition: " + (n1 + n2));
        Console.WriteLine("Subtraction: " + (n1 - n2));
        Console.WriteLine("Multiplication: " + (n1 * n2));
        if (n2 != 0)
            Console.WriteLine("Division: " + (n1 / n2));
        else
            Console.WriteLine("Division by zero not allowed.");
    }

    static void ArithmeticChoice()
    {
        Console.Write("Enter first number: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose operation (+ - * /): ");
        char op = char.Parse(Console.ReadLine());

        switch (op)
        {
            case '+': Console.WriteLine("Result: " + (n1 + n2)); break;
            case '-': Console.WriteLine("Result: " + (n1 - n2)); break;
            case '*': Console.WriteLine("Result: " + (n1 * n2)); break;
            case '/':
                if (n2 != 0) Console.WriteLine("Result: " + (n1 / n2));
                else Console.WriteLine("Cannot divide by zero.");
                break;
            default: Console.WriteLine("Invalid operator."); break;
        }
    }

    static void EvenNumbersAllLoops()
    {
        Console.WriteLine("-- Using for loop --");
        for (int i = 2; i <= 20; i += 2) Console.Write(i + " ");

        Console.WriteLine("\n-- Using while loop --");
        int j = 2;
        while (j <= 20)
        {
            Console.Write(j + " ");
            j += 2;
        }

        Console.WriteLine("\n-- Using do-while loop --");
        int k = 2;
        do
        {
            Console.Write(k + " ");
            k += 2;
        } while (k <= 20);
        Console.WriteLine();
    }

    static void OddNumbersAllLoops()
    {
        Console.WriteLine("-- Using for loop --");
        for (int i = 1; i < 20; i += 2) Console.Write(i + " ");

        Console.WriteLine("\n-- Using while loop --");
        int j = 1;
        while (j < 20)
        {
            Console.Write(j + " ");
            j += 2;
        }

        Console.WriteLine("\n-- Using do-while loop --");
        int k = 1;
        do
        {
            Console.Write(k + " ");
            k += 2;
        } while (k < 20);
        Console.WriteLine();
    }

    static void DisplayTable()
    {
        Console.Write("Enter number to display table: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("-- Using for loop --");
        for (int i = 1; i <= 10; i++)
            Console.WriteLine($"{num} x {i} = {num * i}");

        Console.WriteLine("-- Using while loop --");
        int j = 1;
        while (j <= 10)
        {
            Console.WriteLine($"{num} x {j} = {num * j}");
            j++;
        }

        Console.WriteLine("-- Using do-while loop --");
        int k = 1;
        do
        {
            Console.WriteLine($"{num} x {k} = {num * k}");
            k++;
        } while (k <= 10);
    }
}