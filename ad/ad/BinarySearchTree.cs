using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private NodeBinTree<T> rootNode;
        private int counter;
        
        private int i;
        private T[] returnArray;

        public BinarySearchTree()
        {
            rootNode = null;
            counter = 0;
        }

        /// <summary>
        /// Checks if tree is empty
        /// </summary>
        /// <returns>boolean</returns>
        public bool isEmpty()
        {
            return rootNode == null;
        }

        /// <summary>
        /// gets the first node (the rootnode) of the tree
        /// </summary>
        /// <returns>rootNode</returns>
        public NodeBinTree<T> getRoot()
        {
            return rootNode;
        }

        /// <summary>
        /// Adds a value to the tree
        /// </summary>
        /// <param name="value"></param>
        public void add(T value)
        {
            // if the counter = 0, set a new rootNode
            if (counter == 0)
            {
                rootNode = new NodeBinTree<T>(value);
                counter++;
            }
            // else where to insert the new value;
            else
            {
                NodeBinTree<T> newNode = new NodeBinTree<T>(value);
                NodeBinTree<T> current = rootNode;

                while (true)
                {
                    // check if the value of the new node is less than the current node's value
                    if (newNode.getValue().CompareTo(current.getValue()) < 0)
                    {
                        // if it is, check if left child got is null
                        if (current.leafLeft == null)
                        {
                            // insert new item to left child
                            current.leafLeft = newNode;
                            counter++;
                            break;
                        }
                        // else do this again with the left child of current node
                        else
                        {
                            current = current.leafLeft;
                        }
                    }
                    // check if the value of the new node is greater than the current node's value
                    else if (newNode.getValue().CompareTo(current.getValue()) > 0)
                    {
                        if (current.leafRight == null)
                        {
                            current.leafRight = newNode;
                            counter++;
                            break;
                        }
                        else
                        {
                            current = current.leafRight;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// search if a item exists in the tree
        /// return true if found and false if not found
        /// </summary>
        /// <param name="search"></param>
        /// <returns>boolean</returns>
        public bool search(T search)
        {
            NodeBinTree<T> current = rootNode;
            bool found = false;

            // loop till its at the end in the array or it has been found
            while (current != null && !found)
            {
                // Check if the values are the same
                if (current.getValue().CompareTo(search) == 0)
                {
                    // if so, found
                    found = true;
                }
                // value is greater than search
                else if (current.getValue().CompareTo(search) > 0)
                {
                    current = current.leafLeft;
                }
                // value is less than search
                else
                {
                    current = current.leafRight;
                }
            }
            return found;
        }

        /// <summary>
        /// Delete a given item from the tree and replace this item with another node
        /// </summary>
        /// <param name="key"></param>
        /// <returns>boolean if succeeded or failed</returns>
        public bool Delete(T key)
        {
            NodeBinTree<T> current = rootNode;
            NodeBinTree<T> parent = rootNode;
            bool isLeftChild = true;

            if (current == null || current.getValue() == null)
            {
                return false;
            }
            // loop to find the right node to delete
            while (current.getValue().CompareTo(key) != 0)
            {
                // makes parent node previous used node
                parent = current;

                // checking if the next node should be left or right
                // left
                if (current.getValue().CompareTo(key) > 0)
                {
                    isLeftChild = true;
                    current = current.leafLeft;
                }
                // right
                else
                {
                    isLeftChild = false;
                    current = current.leafRight;
                }

                // if the current node is null, the given value is not in the Binary Search Tree 
                if (current == null)
                {
                    return false;
                }
            }

            // if the left and right child are null
            if (current.leafLeft == null && current.leafRight == null)
            {
                // if the rootnode is the only node in the tree it should be deleted
                if (current == rootNode)
                {
                    rootNode = null;
                }
                // if its the left child, the left child of the parent should be deleted
                else if (isLeftChild)
                {
                    parent.leafLeft = null;
                }
                // if its the right child, the right child is deleted
                else
                {
                    parent.leafRight = null;
                }
            }
            // if the right child is null
            else if (current.leafRight == null)
            {
                if (current == rootNode)
                {
                    rootNode = current.leafRight;
                }
                else if (isLeftChild)
                {
                    parent.leafLeft = current.leafLeft;
                }
                else
                {
                    parent.leafRight = current.leafRight;
                }
            }
            // if the left child is null
            else if (current.leafLeft == null)
            {
                if (current == rootNode)
                {
                    rootNode = current.leafRight;
                }
                else if (isLeftChild)
                {
                    parent.leafLeft = parent.leafRight;
                }
                else
                {
                    parent.leafRight = current.leafRight;
                }
            }
            // if both childs are not null
            else
            {
                // replacer node is node to replace deleted node
                NodeBinTree<T> replacer = getReplacer(current);
                // refactor node childs
                if (current == rootNode)
                {
                    rootNode = replacer;
                }
                else if (isLeftChild)
                {
                    parent.leafLeft = replacer;
                    replacer.leafLeft = current.leafLeft;
                }
                else
                {
                    parent.leafRight = replacer;
                    replacer.leafLeft = current.leafLeft;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delNode"></param>
        /// <returns></returns>
        private NodeBinTree<T> getReplacer(NodeBinTree<T> delNode)
        {
            NodeBinTree<T> replacerParent = delNode;
            NodeBinTree<T> replacer = delNode;
            NodeBinTree<T> current = delNode.leafRight;
            while (current != null)
            {
                // check with which nodes the replacer should refactor;
                replacerParent = current;
                replacer = current;
                current = current.leafLeft;
            }

            if (replacer != delNode.leafRight && replacer.leafLeft != replacer.leafRight && replacer.leafRight != delNode.leafRight)
            {
                // refactor node childs.
                replacer.leafLeft = delNode.leafLeft;
                delNode.leafRight.leafLeft = replacer.leafRight;
                replacer.leafRight = delNode.leafRight;
            }

            return replacer;
        }

        /// <summary>
        /// Returns an array with all nodes values in order of the tree
        /// </summary>
        /// <returns>Array</returns>
        public T[] getInOrder()
        {
            returnArray = new T[counter];
            i = 0;

            inOrder(rootNode);
            return returnArray;
        }

        /// <summary>
        /// Returns an array with all nodes values in pre order of the tree
        /// </summary>
        /// <returns>Array</returns>
        public T[] getPreOrder()
        {
            returnArray = new T[counter];
            i = 0;

            preOrder(rootNode);
            return returnArray;
        }

        /// <summary>
        /// Returns an array with all nodes values in post order of the tree
        /// </summary>
        /// <returns>Array</returns>
        public T[] getPostOrder()
        {
            returnArray = new T[counter];
            i = 0;

            PostOrder(rootNode);
            return returnArray;
        }

        /// <summary>
        /// Method used to loop over the tree to get all nodes values and put them in an arraylist
        /// </summary>
        /// <param name="node"></param>
        private void inOrder(NodeBinTree<T> node)
        {
            NodeBinTree<T> current = node;

            if (current != null)
            {
                inOrder(node.leafLeft);
                returnArray[i] = node.getValue();
                i++;
                inOrder(node.leafRight);
            }
        }

        /// <summary>
        /// Method used to loop over the tree to get all nodes values and put them in an arraylist
        /// </summary>
        /// <param name="node"></param>
        private void preOrder(NodeBinTree<T> node)
        {
            if (node != null)
            {
                returnArray[i] = node.getValue();
                i++;
                preOrder(node.leafLeft);
                preOrder(node.leafRight);
            }
        }

        /// <summary>
        /// Method used to loop over the tree to get all nodes values and put them in an arraylist
        /// </summary>
        /// <param name="node"></param>
        private void PostOrder(NodeBinTree<T> node)
        {
            if (node != null)
            {
                PostOrder(node.leafLeft);
                PostOrder(node.leafRight);
                returnArray[i] = node.getValue();
                i++;
            }
        }

        /// <summary>
        /// check if the current node is a node without child nodes
        /// </summary>
        /// <returns>boolean</returns>
        public bool isLeaf()
        {
            if (!isEmpty())
            {
                return rootNode.isLeaf(ref rootNode);
            }

            return true;
        }

        /// <summary>
        /// going to the "most left" node to find the lowest value as that one is the lowest in the tree
        /// and returns the value of this node
        /// </summary>
        /// <returns>minimum value of the tree</returns>
        public T findMin()
        {
            NodeBinTree<T> current = rootNode;
            while (current.leafLeft != null)
            {
                current = current.leafLeft;
            }
            return current.getValue();
        }

        /// <summary>
        /// going to the "most right" node to find the greatest value as that one is the greatest in the tree
        /// and returns the value of this node
        /// </summary>
        /// <returns>maximum value of the tree</returns>
        public T findMax()
        {
            NodeBinTree<T> current = rootNode;
            while (current.leafRight != null)
            {
                current = current.leafRight;
            }
            return current.getValue();
        }

        /// <summary>
        /// returns how many nodes the tree has
        /// </summary>
        /// <returns>counter</returns>
        public int Counter()
        {
            return counter;
        }
    }
}
