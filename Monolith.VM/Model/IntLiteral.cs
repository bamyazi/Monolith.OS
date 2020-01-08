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

    public T GetValue<T>(ProcessContext context)
    {
      var castType = typeof(T);
      return (T) Convert.ChangeType(_value, castType);
    }

    public EqualityFlag Compare(ProcessContext context, IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        return EqualityFlag.NotEqual;
      }

      var compareValue = expression.GetValue<int>(context);

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

    public void Add(ProcessContext context, IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot add String to Int.");
      }

      _value += expression.GetValue<int>(context);
    }

    public void Subtract(ProcessContext context, IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot substract String from Int.");
      }

      _value -= expression.GetValue<int>(context);
    }

    public void Multiply(ProcessContext context, IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot multiply Int by String.");
      }

      _value *= expression.GetValue<int>(context);
    }

    public void Divide(ProcessContext context, IExpression expression)
    {
      if (expression.DataType == DataType.String)
      {
        throw new Exception("Cannot divide Int by String.");
      }

      _value /= expression.GetValue<int>(context);
    }

    #endregion

    public override string ToString()
    {
      return $"{DataType}[{_value}]";
    }
  }
}