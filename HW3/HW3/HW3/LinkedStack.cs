using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// A single linked list implementation of a ISTackADT from interface.
    /// </summary>
    
    class LinkedStack : IStackADT
    {
        private Node topNode;

        /// <summary>
        /// Simple default constructor that initializes topNode to null.
        /// </summary>
        public LinkedStack()
        {
            topNode = null;
        }

        /// <summary>
        /// Getter and setter.
        /// </summary>
        public Node TopNode
        {
            get { return topNode; }
            set { topNode = value; }
        }

        /// <summary>
        /// Empties the entire stack.
        /// </summary>
        public void Clear()
        {
            this.TopNode = null;
        }

        /// <summary>
        /// Checks if the stack is empty 
        /// </summary>
        /// <returns>False if the stack isn't empty</returns>
        public bool IsEmpty()
        {
            return this.TopNode == null;
        }

        /// <summary>
        /// Returns the top item, does not remove it.
        /// </summary>
        /// <returns>gives reference to the top of the stack. If it is empty it returns null</returns>
        public object Peek()
        {
            return IsEmpty() ? null : TopNode.Data;
        }

        /// <summary>
        /// Both returns and removes the top item from the stack
        /// </summary>
        /// <returns> Removes a reference from the stack</returns>
        public object Pop()
        {
            if (IsEmpty()) { return null; }

            object tempTop = TopNode.Data;
            TopNode = TopNode.NextNode;
            return tempTop;
        }

        /// <summary>
        /// Pushes an item to the top of a stack.
        /// </summary>
        /// <param name="newItem">The item we  pusuh to the top.</param>
        /// <returns>returns a reference if no other item exists.</returns>
        public object Push(object newItem)
        {
            if(newItem == null) { return null; }

            Node newNode = new Node(newItem, TopNode);
            TopNode = newNode;
            return newItem;
        }


    }
}
