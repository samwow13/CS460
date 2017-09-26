using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HW3
{
    /// <summary>
    /// This is an interface that defines a Stack.
    /// 
    /// This is a class created by Scot Morse, rewritten by Sam Wetzel.
    /// </summary>
    public interface IStackADT
    {
        ///<summary>
        ///Remove and return the top item on the stack. This operation should 
        ///result in an error if the stack is empty. Returns a reference to the item 
        ///removed
        //@return reference that was popped (and removed) from the stack or null if
        // the stack is empty
        /// </summary>
        Object Push(Object newItem);

        ///<summary>
        ///Remove and return the top item on the stack. This operation should result in an error if the 
        ///stack is empty. Returns a reference to the item removed.
        //@return A reference that was popped (and removed) from the stack or null if the stack line is empty.
        /// </summary>
        Object Pop();

        ///<summary>
        /// Return the top item but do not remove it. Generally should result in
        /// an error if the stack is empty. An  acceptable alternative is to return 
        /// something which the user can use to check to see if the stack was in fact empty.
        //@returns A reference to the item currently on the top of the stack or null if the stack is empty.
        /// </summary>
        Object Peek();

        ///<summary>
        ///Query the stack to see if it is empty or not. Cannot produce an error.
        ///</summary>
        //@returns True if the stack is empty, false otherwise
        bool IsEmpty();

        ///<summary>
        /// Reset the stack by emptying it. The exact technique used to clear the stack is up to the
        /// implementor. The user should pay attention to what this behavior is.
        /// </summary>
        void Clear();
    }
}