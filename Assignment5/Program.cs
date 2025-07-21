using System;
using System.Collections.Generic;
class Employee
{
    public int ID;
    public string Name, Manager;
    public static int Count = 0;
    public Employee(int id, string name, string manager)
    {
        ID = id; Name = name; Manager = manager;
        Count++;
    }
    public virtual void Display() { }
}
class OnContract : Employee
{
    string ContractDate;
    int Duration;
    double Charges;
    public OnContract(int id, string name, string mgr, string date, int duration, double charges): base(id, name, mgr)
    {
        ContractDate = date; 
        Duration = duration; 
        Charges = charges;
    }
    public override void Display()
    {
        Console.WriteLine($"[Contract] ID:{ID}, Name:{Name}, Charges: ₹{Charges}");
    }
}
class OnPayroll : Employee
{
    string joinDate;
    int Exp;
    double Basic, Net;
    public OnPayroll(int id, string name, string mgr, string joinDate, int exp, double basic) : base(id, name, mgr)
    {
        joinDate = joinDate;
        Exp = exp; Basic = basic;
        double DA = 0, HRA = 0, PF = 0;
        if (Exp > 10) { DA = 0.10 * Basic; HRA = 0.085 * Basic; PF = 6200; }
        else if (Exp > 7) { DA = 0.07 * Basic; HRA = 0.065 * Basic; PF = 4100; }
        else if (Exp > 5) { DA = 0.041 * Basic; HRA = 0.038 * Basic; PF = 1800; }
        else { DA = 0.019 * Basic; HRA = 0.02 * Basic; PF = 1200; }
        Net = Basic + DA + HRA - PF;
    }
    public override void Display()
    {
        Console.WriteLine($"[Payroll] ID:{ID}, Name:{Name}, Join:{joinDate}, Net Salary: ₹{Net}");
    }
}
class Program
{
    static void Main()
    {
        List<Employee> emp = new List<Employee>
        {
            new OnContract(1, "Mukesh", "Ajay", "2023-06-01", 12, 15000),
            new OnPayroll(2, "Ganesh", "Kamal", "2022-12-12", 12, 50000),
            new OnPayroll(3, "Arun", "Abhishek", "2019-08-08", 8, 40000),
            new OnContract(4, "Vijay", "Kiran", "2024-03-03", 6, 30000),
            new OnPayroll(5, "Vikram", "Ram", "2018-06-6", 2, 20000)
        };
        foreach (var e in emp) e.Display();
        Console.WriteLine($"\nTotal Employees: {Employee.Count}");
    }
}