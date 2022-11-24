using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercis3_20190140051
{
    class Node
    {
        //Creates nodes for the circular nexted list
        public int rollNumber;
        public string name;
        public Node next;
    }
    class Circularlist
    {
        Node LAST;

        public Circularlist()
        {
            LAST = null;
        }
        public void addNode()
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Int32.Parse(Console.ReadLine());
            Console.Write("\nEnter name of the student: ");
            nm = Console.ReadLine();

            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            Node previous, current;

            if (LAST == null)
            {
                LAST = newnode;
                newnode.next = LAST;
                return;
            }
            if (rollNo < LAST.next.rollNumber)
            {
                newnode.next = LAST.next;
                LAST.next = newnode;
                return;
            }
            if (rollNo <= LAST.rollNumber)
            {
                if (LAST != null && rollNo == LAST.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }

                current = LAST.next;
                previous = current;
                while (rollNo > current.rollNumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = newnode;
                newnode.next = current;
                return;
            }
            if (rollNo > LAST.rollNumber)
            {
                newnode.next = LAST.next;
                LAST.next = LAST = newnode;
                return;
            }
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST;
                previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);
                //returns true if the node is found
            }
            if (rollNo == LAST.rollNumber)//if the node is present at the end
                return true;
            else
                return (false); //return false if the node is not found
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
            {
                return false;
            }

            if (rollNo == LAST.next.rollNumber) // if the begining node to be deleted
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            }

            if (rollNo == LAST.rollNumber) // if the last node to be deleted
            {
                current = LAST;
                previous = current.next;
                while (previous.next != LAST)
                {
                    previous = previous.next;
                }
                previous.next = LAST.next;
                LAST = previous;
                return true;
            }

            if (rollNo <= LAST.rollNumber)
            {
                current = previous = LAST.next;
                while (rollNo > current.rollNumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = current.next;
            }
            return true;
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse() //traverses all the nodes of the list
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "   " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "    " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" +
                    LAST.next.rollNumber + "    " + LAST.next.name);
        }
    }
}