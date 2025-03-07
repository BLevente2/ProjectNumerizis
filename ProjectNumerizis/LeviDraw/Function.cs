using System;
using System.Collections.Generic;

namespace LeviDraw
{
    /// <summary>
    /// Represents a mathematical function that can be parsed from an expression and evaluated.
    /// </summary>
    public class Function
    {
        private Node root;

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the color associated with the function.
        /// </summary>
        public Color FunctionColor { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the function is enabled.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Function"/> class with the specified name, expression, and color.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <param name="expression">The mathematical expression to be parsed into the function.</param>
        /// <param name="color">The color associated with the function.</param>
        public Function(string name, string expression, Color color)
        {
            Name = name;
            FunctionColor = color;
            List<string> tokens = Tokenize(expression);
            int i = 0;
            root = ParseExpression(tokens, ref i);
        }

        /// <summary>
        /// Evaluates the function for the specified x value.
        /// </summary>
        /// <param name="x">The x value for which the function is evaluated.</param>
        /// <returns>The result of the function at the given x value.</returns>
        public double Evaluate(double x)
        {
            return root.Evaluate(x);
        }

        /// <summary>
        /// Tokenizes the provided mathematical expression into a list of string tokens.
        /// </summary>
        /// <param name="expression">The expression to be tokenized.</param>
        /// <returns>A list of tokens extracted from the expression.</returns>
        private static List<string> Tokenize(string expression)
        {
            List<string> tokens = new List<string>();
            int i = 0;
            while (i < expression.Length)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == '.')
                {
                    string number = "";
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        number += expression[i];
                        i++;
                    }
                    tokens.Add(number);
                }
                else if (char.IsLetter(c))
                {
                    string func = "";
                    while (i < expression.Length && char.IsLetter(expression[i]))
                    {
                        func += expression[i];
                        i++;
                    }
                    if (func == "e")
                    {
                        tokens.Add(Math.E.ToString());
                    }
                    else if (func == "PI" || func == "pi")
                    {
                        tokens.Add(Math.PI.ToString());
                    }
                    else
                    {
                        tokens.Add(func);
                    }
                }
                else if ("+-*/^{}()".Contains(c))
                {
                    if (c == '-' && (tokens.Count == 0 || "+-*/^({".Contains(tokens[^1])))
                    {
                        tokens.Add("NEG");
                    }
                    else
                    {
                        tokens.Add(c.ToString());
                    }
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return tokens;
        }

        /// <summary>
        /// Parses the list of tokens into a tree structure that represents the mathematical expression.
        /// </summary>
        /// <param name="tokens">The list of tokens to be parsed.</param>
        /// <param name="i">The index reference for parsing.</param>
        /// <returns>The root node of the parsed expression tree.</returns>
        private Node ParseExpression(List<string> tokens, ref int i)
        {
            Stack<Node> output = new Stack<Node>();
            Stack<string> operators = new Stack<string>();

            while (i < tokens.Count)
            {
                string token = tokens[i];
                if (IsOperator(token))
                {
                    while (operators.Count > 0 && OperatorPrecedence(operators.Peek()) >= OperatorPrecedence(token))
                    {
                        string op = operators.Pop();
                        Node right = output.Pop();
                        Node left = output.Pop();
                        output.Push(new OperatorNode(op, left, right));
                    }
                    operators.Push(token);
                    i++;
                }
                else
                {
                    Node node = ParsePrimary(tokens, ref i);
                    output.Push(node);
                }
            }

            while (operators.Count > 0)
            {
                string op = operators.Pop();
                Node right = output.Pop();
                Node left = output.Pop();
                output.Push(new OperatorNode(op, left, right));
            }

            return output.Pop();
        }

        /// <summary>
        /// Parses a continuation expression, applying operators to the given left node.
        /// </summary>
        /// <param name="left">The left node of the expression.</param>
        /// <param name="tokens">The list of tokens.</param>
        /// <param name="i">The current index in the token list.</param>
        /// <returns>The resulting expression node after parsing the continuation.</returns>
        private Node ParseContinuation(Node left, List<string> tokens, ref int i)
        {
            while (i < tokens.Count && IsOperator(tokens[i]))
            {
                string op = tokens[i];
                i++;
                Node right = ParsePrimary(tokens, ref i);
                left = new OperatorNode(op, left, right);
            }
            return left;
        }

        /// <summary>
        /// Parses a function call and its arguments from the token list.
        /// </summary>
        /// <param name="func">The function name.</param>
        /// <param name="tokens">The list of tokens.</param>
        /// <param name="i">The current index in the token list.</param>
        /// <returns>The function node after parsing.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the function is not properly formatted.</exception>
        private Node ParseFunction(string func, List<string> tokens, ref int i)
        {
            i++;

            if (i >= tokens.Count || tokens[i] != "{")
            {
                throw new IndexOutOfRangeException("Expected '{' after function name.");
            }

            i++;
            int braceCount = 1;
            List<string> subTokens = new List<string>();
            while (i < tokens.Count && braceCount > 0)
            {
                if (tokens[i] == "{")
                {
                    braceCount++;
                }
                else if (tokens[i] == "}")
                {
                    braceCount--;
                }
                if (braceCount > 0) subTokens.Add(tokens[i]);
                i++;
            }

            if (braceCount != 0)
            {
                throw new IndexOutOfRangeException("Mismatched braces in function.");
            }

            int subIndex = 0;
            Node argument = ParseExpression(subTokens, ref subIndex);
            Node functionNode = new FunctionNode(func, argument);

            return ParseContinuation(functionNode, tokens, ref i);
        }

        /// <summary>
        /// Parses the primary expression from the token list.
        /// </summary>
        /// <param name="tokens">The list of tokens.</param>
        /// <param name="i">The current index in the token list.</param>
        /// <returns>The primary expression node.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if an unexpected end of tokens is encountered.</exception>
        /// <exception cref="Exception">Thrown if an unknown token is encountered.</exception>
        private Node ParsePrimary(List<string> tokens, ref int i)
        {
            if (i >= tokens.Count)
            {
                throw new IndexOutOfRangeException("Unexpected end of tokens.");
            }

            string token = tokens[i];

            if (double.TryParse(token, out double number))
            {
                i++;
                return new ConstantNode(number);
            }
            else if (token == "x")
            {
                i++;
                return new VariableNode();
            }
            else if (token == "(")
            {
                i++;
                Node expr = ParseExpression(tokens, ref i);
                if (i >= tokens.Count || tokens[i] != ")")
                {
                    throw new IndexOutOfRangeException("Mismatched parentheses.");
                }
                i++;
                return expr;
            }
            else if (token == "NEG")
            {
                i++;
                return new NegateNode(ParsePrimary(tokens, ref i));
            }
            else if (char.IsLetter(token[0]))
            {
                return ParseFunction(token, tokens, ref i);
            }
            else
            {
                throw new Exception("Unknown token: " + token);
            }
        }

        /// <summary>
        /// Determines whether the given token is an operator.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <returns><c>true</c> if the token is an operator; otherwise, <c>false</c>.</returns>
        private static bool IsOperator(string token)
        {
            return "+-*/^".Contains(token);
        }

        /// <summary>
        /// Returns the precedence level of the specified operator.
        /// </summary>
        /// <param name="op">The operator.</param>
        /// <returns>An integer representing the precedence level of the operator.</returns>
        private static int OperatorPrecedence(string op)
        {
            return op == "+" || op == "-" ? 1 :
                   op == "*" || op == "/" ? 2 :
                   op == "^" ? 3 : 0;
        }
    }
}