using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    //Based on: http://codereview.stackexchange.com/questions/92618/simple-binary-search-tree

    class BinarySearchTreecs
    {
        private Node rootNode;
        private int counter;
		
		//Return  counter
		public int counter { get; private set; }
        
		//Set rootNode on null and set counter on 0 
		public BinarySearchTreecs()
        {
            rootNode = null;
            counter = 0;
        }

		//Check if rootNode is null
        public bool isEmpty()
        {
            return rootNode == null;
        }

        //
		//Add a new node with data
		public void add(int value)
        {
            if (IsEmpty)
            {
                rootNode = new Node(value);
            }
            else
            {
                rootNode.dataInsert(ref rootNode, value);
            }

            counter++;
        }

		// ?!!?!?!?!?!?!?!?!?!?!?!?!?!?
        public bool search(int search)
        {
            return rootNode.search(rootNode, search);
        }

		// ?!?!!!?!??!?!?!?!??!?!?!?!?!?!?
        public bool isLeaf()
        {
            if (!isEmpty())
            {
                return rootNode.isLeaf(ref rootNode);
            }

            return true;
        }

		//Display node
        public void display()
        {
            if (!isEmpty())
            {
                rootNode.display(rootNode);
            }
        }

       

    }
}
