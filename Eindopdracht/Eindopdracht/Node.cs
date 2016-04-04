using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    //Based on: http://codereview.stackexchange.com/questions/92618/simple-binary-search-tree

    class Node
    {
        private int num;
        public Node leafLeft;
        public Node leafRight;

        //Set num with value, set leafLeft and leafRight on null 
		public Node(int value)
        {
            num = value;
            leafLeft = null;
            leafRight = null;
        }
        
        //Refference to node
		//Set leafLeft and leafRight on null
	    public bool isLeaf(ref Node node)
        {
            return (node.leafRight == null && node.leafLeft == null);
        }

		//Refference to node  !in data!                      ---------
        public void dataInsert(ref Node node, int data)
        {
            if (node == null)
            {
                node = new Node(data);
            }

            else if (node.num < data)
            {
                dataInsert(ref node.leafRight, data);
            }

            else if (node.num > data)
            {
                dataInsert(ref node.leafLeft, data);
            }
        }

		//
		//Put new node in the tree with nodes in numeric order
        public bool search (Node node, int s)
        {
            if (node == null)
            {
                return false;
            }

            if (node.num == s)
            {
                return true;
            }

            else if (node.num < s)
            {
                return search(node.leafRight, s);
            }

            else if (node.num > s)
            {
                return search(node.leafLeft, s);
            }

            return false;
        }

		//Display nodes
        public void display (Node n)
        {
            if (n == null)
            {
                return;
            }

            display(n.leafLeft);
            Console.Write(" " + n.num);
            display(n.leafRight);
        }
    }
}
