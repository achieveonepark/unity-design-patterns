using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExpression
{
    int Interpret();
}

public class NumberExpression : IExpression
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }
    
    public int Interpret()
    {
        return _number;
    }
}

public class AddExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }
    
    public int Interpret()
    {
        return _left.Interpret() + _right.Interpret();
    }
}

public class SubExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public SubExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }
    
    public int Interpret()
    {
        return _left.Interpret() - _right.Interpret();
    }
}

