using System;

namespace LeviDraw
{
    /// <summary>
    /// Represents a node in an expression tree that performs a mathematical operation 
    /// between two other nodes (left and right).
    /// </summary>
    class OperatorNode : Node
    {
        private string op;
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class with the specified operator, left node, and right node.
        /// </summary>
        /// <param name="op">The operator to apply, such as +, -, *, /, or ^.</param>
        /// <param name="left">The left operand of the operator.</param>
        /// <param name="right">The right operand of the operator.</param>
        public OperatorNode(string op, Node left, Node right)
        {
            this.op = op;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Evaluates the result of applying the operator to the left and right nodes for the given x value.
        /// </summary>
        /// <param name="x">The value for which the operator is evaluated.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="Exception">Thrown if an unknown operator is encountered.</exception>
        public override double Evaluate(double x)
        {
            switch (op)
            {
                case "+":
                    return left.Evaluate(x) + right.Evaluate(x);
                case "-":
                    return left.Evaluate(x) - right.Evaluate(x);
                case "*":
                    return left.Evaluate(x) * right.Evaluate(x);
                case "/":
                    return left.Evaluate(x) / right.Evaluate(x);
                case "^":
                    return Math.Pow(left.Evaluate(x), right.Evaluate(x));
                default:
                    throw new Exception("Unknown operator");
            }
        }
    }
}