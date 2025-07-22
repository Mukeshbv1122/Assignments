using System;
using System.Collections.Generic;
class Product
{
    public int PCode;
    public string PName;
    public int QtyInStock;
    public double Price;
    public static string Brand = "TechZone";
    public static List<Product> products = new List<Product> {
        new Product{PCode=1, PName="Laptop", QtyInStock=10, Price=50000},
        new Product{PCode=2, PName="Mouse", QtyInStock=50, Price=500},
        new Product{PCode=3, PName="Keyboard", QtyInStock=30, Price=1000},
        new Product{PCode=4, PName="Monitor", QtyInStock=20, Price=8000},
        new Product{PCode=5, PName="Printer", QtyInStock=15, Price=12000}
    };
    public static void DisplayAll()
    {
        Console.WriteLine("\n--- Product List ---");
        foreach (var p in products)
            Console.WriteLine($"Code: {p.PCode}, Name: {p.PName}, Qty: {p.QtyInStock}, Price: ₹{p.Price}, Brand: {Brand}");
    }
    public static void PurchaseProduct()
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();
        Product prod = products.Find(p => p.PName.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (prod == null) { Console.WriteLine("Product not found."); return; }

        Console.Write("Enter Quantity to Buy: ");
        int qty = int.Parse(Console.ReadLine());
        if (qty > prod.QtyInStock) { Console.WriteLine("Not enough stock."); return; }

        double total = prod.Price * qty;
        double discount = total * 0.5;
        double final = total - discount;
        Console.WriteLine($"\n--- Bill ---");
        Console.WriteLine($"Product: {prod.PName}, Qty: {qty}, Price: ₹{prod.Price}");
        Console.WriteLine($"Total: ₹{total}, Discount: ₹{discount}, Amount to Pay: ₹{final}");
    }
}
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Admin View\n2. Purchase Product\n3. Exit\nEnter choice:");
            string choice = Console.ReadLine();
            if (choice == "1") Product.DisplayAll();
            else if (choice == "2") Product.PurchaseProduct();
            else if (choice == "3") break;
            else Console.WriteLine("Invalid choice.");
        }
    }
}