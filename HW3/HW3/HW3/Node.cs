using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// A single linked node class for use in this project.
    /// </summary>
    class Node
    {
        object data; // contents of the node
        Node nextNode; // reference to the next Node in the chain.

        ///<summary>
        ///Constructor that creates a new node
        /// </summary>
        public Node(object data, Node nextNode)
        {
            this.data = data;
            this.nextNode = nextNode;
        }

        ///<summary>
        /// property to get and set the data contents
        /// </summary>
        public object Data
        {
               get { return data; }
               set { data = value; }
           
        }

        /// <summary>
        /// property to get and set the next node.
        /// </summary>
        public Node NextNode
        {
            get { return nextNode; }
            set { nextNode = value; }
        }


    }


}
