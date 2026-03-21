using System;


namespace Dotnet_C__Demo.HandsOn_week5_day1
{
    class Node
    {
        public int empId;
        public string name;
        public Node next;

        public Node(int id,string name) {
        this.empId = id;
        this.name = name;
            this.next = null;

        }
    }
    //linked list class
    class EmployeeLinkedList
    {
        private Node head;
        //insert at beginning
        public void InsertAtbeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.next = head;
            head = newNode;
        }
        //insert at end
        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
        }
        //delete by employee id
        public void Delete(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }
            //if head needs to be deleted
            if (head.empId == id)
            {
                head = head.next;
                return;
            }
            Node temp = head;
            Node prev = null;
            while (temp != null && temp.empId != id)
            {
                prev = temp;
                temp = temp.next;
            }
            //if employee not found
            if (temp == null)
            {
                Console.WriteLine("Employee not found.");
                return;

            }
            //remove node
            prev.next = temp.next;
        }
        //display list
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.empId + "-" + temp.name);
                temp = temp.next;

            }
        }
    }
    internal class problem3
    {
        static void Main()
        {
            EmployeeLinkedList list = new EmployeeLinkedList();
            //insert employees
            list.InsertAtEnd(101, "Jhon");
            list.InsertAtEnd(102, "Sara");
            list.InsertAtEnd(103, "Mike");

            //delete employee with id 102
            list.Delete(102);

            //display result
            Console.WriteLine("Employee List After Deletion:");
            list.Display();
        }
    }
}
