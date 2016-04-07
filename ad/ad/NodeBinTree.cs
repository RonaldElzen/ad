using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad
{
    //Based on: http://codereview.stackexchange.com/questions/92618/simple-binary-search-tree
    public class NodeBinTree<T>
    {
        private T value;
        public NodeBinTree<T> leafLeft;
        public NodeBinTree<T> leafRight;

        public NodeBinTree(T item)
        {
            value = item;
            leafLeft = null;
            leafRight = null;
        }

        /// <summary>
        /// Checks if the node is a node without any childelements
        /// </summary>
        /// <param name="node"></param>
        /// <returns>boolean</returns>
        public bool isLeaf(ref NodeBinTree<T> node)
        {
            return (node.leafRight == null && node.leafLeft == null);
        }

        /// <summary>
        /// gets the value of the node 
        /// </summary>
        /// <returns>value</returns>
        public T getValue()
        {
            return value;
        }
    }
}
