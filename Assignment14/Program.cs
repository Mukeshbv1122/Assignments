using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14
{
    class Node
    {
        public int data;
        public Node nextNode;
    }
    internal class StackUsingLinkedList
    {
        Node first = null;
        Node New = null;
        public StackUsingLinkedList() { }
        public void Push(int data)
        {
            New = new Node();
            New.data = data;
            New.nextNode = first;
            first = New;
            Console.WriteLine("Node added to stack.");
        }
        public void Pop()
        {
            if (first == null)
            {
                Console.WriteLine("Stack Underflow.");
                return;
            }
            Console.WriteLine("Popped element: " + first.data);
            first = first.nextNode;
        }
        public void Display()
        {
            if (first == null)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            Console.WriteLine("Stack elements (first to last):");
            Node ptr;
            for (ptr = first; ptr != null; ptr = ptr.nextNode)
            {
                Console.WriteLine(ptr.data);
            }
        }
        static void Main()
        {
            StackUsingLinkedList stack = new StackUsingLinkedList();
            string choice = "yes";
            while (choice.ToLower() == "yes")
            {
                Console.WriteLine("Enter data to push:");
                int num = int.Parse(Console.ReadLine());
                stack.Push(num);
                Console.WriteLine("Do you want to push more? [yes/no]:");
                choice = Console.ReadLine();
            }
            stack.Display();
            Console.WriteLine("Do you want to pop an element? [yes/no]:");
            choice = Console.ReadLine();
            while (choice.ToLower() == "yes")
            {
                stack.Pop();
                stack.Display();
                Console.WriteLine("Pop again? [yes/no]:");
                choice = Console.ReadLine();
            }
        }
    }
}