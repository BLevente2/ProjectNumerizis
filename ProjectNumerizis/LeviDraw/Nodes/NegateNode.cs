using System;

namespace LeviDraw
{
    /// <summary>
    /// Represents a node in an expression tree that negates the value of its child node.
    /// </summary>
    class NegateNode : Node
    {
        private Node expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="NegateNode"/> class with the specified expression node.
        /// </summary>
        /// <param name="expression">The node representing the expression to be negated.</param>
        public NegateNode(Node expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Evaluates the node by negating the result of the child expression.
        /// </summary>
        /// <param name="x">The input value for which the expression is evaluated.</param>
        /// <returns>The negated result of the expression evaluation.</returns>
        public override double Evaluate(double x)
        {
            return -expression.Evaluate(x);
        }
    }
}