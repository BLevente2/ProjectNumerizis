using System;

namespace LeviDraw
{
    /// <summary>
    /// Represents a node in an expression tree that applies a mathematical function to an argument node.
    /// </summary>
    class FunctionNode : Node
    {
        private string function;
        private Node argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionNode"/> class with the specified function and argument node.
        /// </summary>
        /// <param name="function">The name of the mathematical function to apply (e.g., sin, cos, log).</param>
        /// <param name="argument">The argument node on which the function is applied.</param>
        public FunctionNode(string function, Node argument)
        {
            this.function = function;
            this.argument = argument;
        }

        /// <summary>
        /// Evaluates the function node by applying the specified mathematical function to the argument node.
        /// </summary>
        /// <param name="x">The input value for evaluating the function's argument.</param>
        /// <returns>The result of applying the function to the argument.</returns>
        /// <exception cref="Exception">Thrown if an unknown function is encountered.</exception>
        public override double Evaluate(double x)
        {
            double argValue = argument.Evaluate(x);
            switch (function)
            {
                case "sin":
                    return Math.Sin(argValue);
                case "cos":
                    return Math.Cos(argValue);
                case "tan":
                    return Math.Tan(argValue);
                case "log":
                    return Math.Log2(argValue);
                case "abs":
                    return Math.Abs(argValue);
                case "ln":
                    return Math.Log(argValue);
                case "lg":
                    return Math.Log10(argValue);
                case "sqrt":
                    return Math.Sqrt(argValue);
                case "asin":
                    return Math.Asin(argValue);
                case "acos":
                    return Math.Acos(argValue);
                case "atan":
                    return Math.Atan(argValue);
                case "sinh":
                    return Math.Sinh(argValue);
                case "cosh":
                    return Math.Cosh(argValue);
                case "tanh":
                    return Math.Tanh(argValue);
                default:
                    throw new Exception("Unknown function");
            }
        }
    }
}