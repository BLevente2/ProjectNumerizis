using System;

namespace LeviDraw
{
    /// <summary>
    /// Represents an abstract base class for nodes in a mathematical expression tree.
    /// </summary>
    abstract class Node
    {
        /// <summary>
        /// Evaluates the node for the given x value.
        /// </summary>
        /// <param name="x">The value for which the node is evaluated.</param>
        /// <returns>The result of the evaluation as a double.</returns>
        public abstract double Evaluate(double x);
    }
}