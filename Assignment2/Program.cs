using System;

class Assignment2
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== MAIN MENU =====");
            Console.WriteLine("1. Check Admission Eligibility");
            Console.WriteLine("2. Generate Electricity Bill");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(); // Line break

            switch (choice)
            {
                case 1:
                    CheckAdmissionEligibility();
                    break;

                case 2:
                    GenerateElectricityBill();
                    break;

                case 0:
                    Console.WriteLine("Exiting program. Thank you!");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please select 1, 2, or 0.");
                    break;
            }

        } while (choice != 0);
    }

    static void CheckAdmissionEligibility()
    {
        Console.Write("Input the marks obtained in Physics: ");
        int physics = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input the marks obtained in Chemistry: ");
        int chemistry = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input the marks obtained in Mathematics: ");
        int maths = Convert.ToInt32(Console.ReadLine());

        int total = physics + chemistry + maths;
        int mathPhyTotal = maths + physics;

        if (maths >= 65 && physics >= 55 && chemistry >= 50 &&
            (total >= 180 || mathPhyTotal >= 140))
        {
            Console.WriteLine(" The candidate is eligible for admission.");
        }
        else
        {
            Console.WriteLine(" The candidate is not eligible for admission.");
        }
    }

    static void GenerateElectricityBill()
    {
        Console.Write("Enter Customer ID: ");
        string customerID = Console.ReadLine();

        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter Units Consumed: ");
        int units = int.Parse(Console.ReadLine());

        double chargePerUnit = 0;
        double billAmount = 0;
        double surcharge = 0;
        double totalAmount = 0;

        if (units <= 199)
        {
            chargePerUnit = 1.20;
        }
        else if (units >= 200 && units < 400)
        {
            chargePerUnit = 1.50;
        }
        else if (units >= 400 && units < 600)
        {
            chargePerUnit = 1.80;
        }
        else // 600 and above
        {
            chargePerUnit = 2.00;
        }

        billAmount = units * chargePerUnit;

        if (billAmount > 400)
        {
            surcharge = billAmount * 0.15;
        }

        totalAmount = billAmount + surcharge;

        if (totalAmount < 100)
        {
            totalAmount = 100;
        }

        Console.WriteLine("\n--- Electricity Bill ---");
        Console.WriteLine("Customer ID       : " + customerID);
        Console.WriteLine("Customer Name     : " + customerName);
        Console.WriteLine("Units Consumed    : " + units);
        Console.WriteLine("Charge per Unit   : Rs. " + chargePerUnit.ToString("0.00"));
        Console.WriteLine("Bill Amount       : Rs. " + billAmount.ToString("0.00"));
        Console.WriteLine("Surcharge         : Rs. " + surcharge.ToString("0.00"));
        Console.WriteLine("Total Amount to Pay: Rs. " + totalAmount.ToString("0.00"));
    }
}