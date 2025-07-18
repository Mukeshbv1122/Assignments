using System;
using System.Collections.Generic;
class Product
{
    public string Pcode, Pname;
    public int QtyInStock;
    public static string Brand = "Lenovo";
    public static double DiscountAllowed = 0.50;
    public Product(string code, string name, int qty)
    {
        Pcode = code;
        Pname = name;
        QtyInStock = qty;
    }
    public void Display() =>
        Console.WriteLine($"Code: {Pcode}, Name: {Pname}, Stock: {QtyInStock}, Brand: {Brand}, Discount: {DiscountAllowed * 100}%");
    public double GetBill(int qty, double price) => qty * price * (1 - DiscountAllowed);
}
class Program
{
    static List<Product> products = new List<Product>();
    const double pricePerItem = 100;
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n Who are you?\n1. Admin\n2. Customer\n3. Exit");
            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 1) 
                Menu();
            else if (ch == 2) 
                CustomerMenu();
            else if (ch == 3)
                break;
            else 
                Console.WriteLine("Invalid choice.");
        }
    }
    static void Menu()
    {
        Console.Write("Enter Product Code: ");
        string code = Console.ReadLine();
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Stock Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());
        products.Add(new Product(code, name, qty));
        Console.WriteLine("Product Added.");
    }
    static void CustomerMenu()
    {
        Console.Write("Enter Product Name to buy: ");
        string name = Console.ReadLine();
        Product prod = products.Find(p => p.Pname.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (prod != null)
        {
            prod.Display();
            Console.Write("Enter Quantity to purchase: ");
            int qty = Convert.ToInt32(Console.ReadLine());
            if (qty <= prod.QtyInStock)
            {
                double total = pricePerItem * qty;
                double final = prod.GetBill(qty, pricePerItem);
                Console.WriteLine($"\n BILL \nProduct: {prod.Pname}\nQty: {qty}\nTotal: ₹{total}\nDiscounted: ₹{final}\n");
                prod.QtyInStock -= qty;
            }
            else Console.WriteLine("Not enough stock.");
        }
        else Console.WriteLine("Product not found.");
    }
}