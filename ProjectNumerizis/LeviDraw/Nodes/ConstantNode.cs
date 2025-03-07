using System;

namespace LeviDraw
{
    /// <summary>
    /// Represents a node in an expression tree that holds a constant numeric value.
    /// </summary>
    class ConstantNode : Node
    {
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class with the specified constant value.
        /// </summary>
        /// <param name="value">The constant numeric value represented by this node.</param>
        public ConstantNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Evaluates the node by returning the constant value it holds.
        /// </summary>
        /// <param name="x">The input value (not used in this node type, but required by the interface).</param>
        /// <returns>The constant value held by this node.</returns>
        public override double Evaluate(double x)
        {
            return value;
        }
    }
}