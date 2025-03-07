using System;

namespace LeviDraw
{
    /// <summary>
    /// Represents a node in an expression tree that returns the value of the variable (x).
    /// </summary>
    class VariableNode : Node
    {
        /// <summary>
        /// Evaluates the node by returning the value of the variable (x).
        /// </summary>
        /// <param name="x">The input value for the variable.</param>
        /// <returns>The value of the variable (x).</returns>
        public override double Evaluate(double x)
        {
            return x;
        }
    }
}