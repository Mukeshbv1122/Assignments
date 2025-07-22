using System;
using System.Collections;
class Pizza
{
    private string pizzaSize;
    private int cheese, chicken, veg;
    public Pizza(string size, int cheese, int chicken, int veg)
    {
        pizzaSize = size;
        this.cheese = cheese;
        this.chicken = chicken;
        this.veg = veg;
    }
    public double Cost()
    {
        int totalToppings = cheese + chicken + veg;
        return pizzaSize.ToLower() switch
        {
            "small" => 10 + 2 * totalToppings,
            "medium" => 12 + 2 * totalToppings,
            "large" => 14 + 2 * totalToppings,
            _ => 0
        };
    }
    public string GetDescription()
    {
        return $"Size: {pizzaSize}, Cheese: {cheese}, Chicken: {chicken}, Veg: {veg}, Cost: ${Cost()}";
    }
}
class Program
{
    static void Main()
    {
        List<Pizza> pizzas = new List<Pizza>();
        while (true)
        {
            Console.WriteLine("Pizza Menu");
            Console.WriteLine("1. Add Pizza");
            Console.WriteLine("2. Show All Pizzas");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Enter size (Small/Medium/Large): ");
                string size = Console.ReadLine();
                Console.Write("Enter cheese toppings: ");
                int cheese = int.Parse(Console.ReadLine());
                Console.Write("Enter chicken toppings: ");
                int chicken = int.Parse(Console.ReadLine());
                Console.Write("Enter veg toppings: ");
                int veg = int.Parse(Console.ReadLine());
                pizzas.Add(new Pizza(size, cheese, chicken, veg));
                Console.WriteLine("Pizza added successfully!");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Pizza Records");
                foreach (Pizza p in pizzas)
                    Console.WriteLine(p.GetDescription());
            }
            else if (choice == 3)
            {
                Console.WriteLine("Visit Again!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
