using System.Collections.Generic;

public class Interpreter
{
    public static IExpression Parse(string input)
    {
        Stack<IExpression> stack = new Stack<IExpression>();
        
        string[] tokens = input.Split(' ');

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var value))
            {
                stack.Push(new NumberExpression(value));
            }
            else if (token.StartsWith("-"))
            {
                IExpression right = stack.Pop();
                IExpression left = stack.Pop();
                stack.Push(new SubExpression(left, right));
            }
            else if (token.StartsWith("+"))
            {
                IExpression right = stack.Pop();
                IExpression left = stack.Pop();
                stack.Push(new AddExpression(left, right));
            }
        }
        
        return stack.Pop();
    }
}