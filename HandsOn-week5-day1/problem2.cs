using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Dotnet_C__Demo.HandsOn_week5_day1
{
    class UndoStack
    {
        private string[] stack;
        private int top;
        private int capacity;

        //constructor
        public UndoStack(int size)
        {
            capacity = size;
            stack = new string[capacity];
            top = -1;
        }
        //push operation
        public void push(string action)
        {
            if (top == capacity - 1)
            {
                Console.WriteLine("Stack Overflow! Cannot add more actions.");
                return;
            }
            stack[++top] = action;
            Console.WriteLine("Action Performed:" + action);
            Display();
        }
        //pop operation
        public void pop() {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow! Nothing to undo.");
                return;
            }
            Console.WriteLine("undo Action:" + stack[top]);
            top--;
            Display();

        }
        //display current state
        public void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("Current State: Empty\n");
                return;
            }
            Console.WriteLine("Current State:");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine("\n");
        }
    }
    internal class problem2
    {
        static void Main()
        {
            UndoStack undo = new UndoStack(10);
            //pushing data
            undo.push("Type A");
            undo.push("Type B");
            undo.push("Type C");
            //poping data
            undo.pop();
            undo.pop();
        }

    }
}
