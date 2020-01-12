using System;

namespace Monolith.VM.Model
{
  public class IntLiteral : IExpression
  {
    private int _value;

    public IntLiteral(int value)
    {
      _value = value;
    }

    public IExpression Clone()
    {
      return new IntLiteral(_value);
    }

    #region IExpression Members

    public DataType DataType => DataType.Int;

    public T GetValue<T>()
    {
      var castType = typeof(T);
      return (T) Convert.ChangeType(_value, castType);
    }

    public EqualityFlag Compare(IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        return EqualityFlag.NotEqual;
      }

      var compareValue = expression.GetValue<int>();

      if (_value == compareValue)
      {
        return EqualityFlag.Equal;
      }

      if (_value < compareValue)
      {
        return EqualityFlag.Less;
      }

      return EqualityFlag.Greater;
    }

    public void Add(IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot add String to Int.");
      }

      _value += expression.GetValue<int>();
    }

    public void Subtract(IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot substract String from Int.");
      }

      _value -= expression.GetValue<int>();
    }

    public void Multiply(IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot multiply Int by String.");
      }

      _value *= expression.GetValue<int>();
    }

    public void Divide(IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot divide Int by String.");
      }

      _value /= expression.GetValue<int>();
    }

    #endregion

    public override string ToString()
    {
      return $"{DataType}[{_value}]";
    }
  }
}