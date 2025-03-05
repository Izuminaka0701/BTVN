using System;
using System.Collections.Generic;

public class Node
{
    public int Data { get; set; }
    public int Count { get; set; } = 1;
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }
}

public class BinarySearchTree
{
    public Node Root { get; set; }
    private int edgeCount = 0;

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node { Data = value };
            return;
        }
        InsertRecursively(Root, value);
    }

    private void InsertRecursively(Node node, int value)
    {
        if (value < node.Data)
        {
            if (node.LeftNode == null)
            {
                node.LeftNode = new Node { Data = value };
                edgeCount++;
            }
            else
                InsertRecursively(node.LeftNode, value);
        }
        else if (value > node.Data)
        {
            if (node.RightNode == null)
            {
                node.RightNode = new Node { Data = value };
                edgeCount++;
            }
            else
                InsertRecursively(node.RightNode, value);
        }
        else
        {
            node.Count++;
        }
    }

    public void TraverseInOrder(Node node)
    {
        if (node != null)
        {
            TraverseInOrder(node.LeftNode);
            Console.WriteLine($"Value: {node.Data}, Count: {node.Count}");
            TraverseInOrder(node.RightNode);
        }
    }

    public int GetEdgeCount() => edgeCount;
}

public class ExpressionNode
{
    public string Value { get; set; }
    public ExpressionNode Left { get; set; }
    public ExpressionNode Right { get; set; }
}

public class ExpressionTree
{
    private ExpressionNode root;

    public ExpressionTree(string postfixExpression)
    {
        Stack<ExpressionNode> stack = new Stack<ExpressionNode>();
        foreach (var token in postfixExpression.Split())
        {
            if (int.TryParse(token, out _))
                stack.Push(new ExpressionNode { Value = token });
            else
            {
                ExpressionNode node = new ExpressionNode { Value = token };
                node.Right = stack.Pop();
                node.Left = stack.Pop();
                stack.Push(node);
            }
        }
        root = stack.Pop();
    }

    public int Evaluate() => Evaluate(root);

    private int Evaluate(ExpressionNode node)
    {
        if (int.TryParse(node.Value, out int number)) return number;
        int left = Evaluate(node.Left);
        int right = Evaluate(node.Right);
        return node.Value switch
        {
            "+" => left + right,
            "-" => left - right,
            "*" => left * right,
            "/" => left / right,
            _ => throw new InvalidOperationException("Invalid Operator")
        };
    }
}

public class Program
{
    public static void Main()
    {
        Console.Clear();
        BinarySearchTree bst = new BinarySearchTree();
        Random random = new Random();
        for (int i = 0; i < 10000; i++)
            bst.Insert(random.Next(0, 10));
        Console.WriteLine("In-Order Traversal with Counts:");
        bst.TraverseInOrder(bst.Root);
        Console.WriteLine($"Total Edges: {bst.GetEdgeCount()}");

        string expression = "2 3 + 4 * 5 /";
        ExpressionTree exprTree = new ExpressionTree(expression);
        Console.WriteLine($"Expression Result: {exprTree.Evaluate()}");
    }
}
