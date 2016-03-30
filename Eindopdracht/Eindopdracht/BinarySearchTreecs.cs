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

        public BinarySearchTreecs()
        {
            rootNode = null;
            counter = 0;
        }

        public bool isEmpty()
        {
            return rootNode == null;
        }

        public void add(int value)
        {
            if (value == 0)
            {
                rootNode = new Node(value);
            }
            else
            {
                rootNode.dataInsert(ref rootNode, value);
            }

            counter++;
        }

        public bool search(int search)
        {
            return rootNode.search(rootNode, search);
        }

        public bool isLeaf()
        {
            if (!isEmpty())
            {
                return rootNode.isLeaf(ref rootNode);
            }

            return true;
        }

        public void display()
        {
            if (!isEmpty())
            {
                rootNode.display(rootNode);
            }
        }

        public int Counter()
        {
            return counter;
        }
    }
}
