using System;

namespace Monolith.VM.Model
{
  public class StringLiteral : IExpression
  {
    private string _value;

    public StringLiteral(string value)
    {
      _value = value.Replace("\"\"", "\"");
    }

    public IExpression Clone()
    {
      return new StringLiteral(_value);
    }

    #region IExpression Members

    public DataType DataType => DataType.String;

    public T GetValue<T>()
    {
      var castType = typeof(T);
      return (T) Convert.ChangeType(_value, castType);
    }

    public EqualityFlag Compare(IExpression expression)
    {
      if (expression.DataType != DataType.String)
      {
        return EqualityFlag.NotEqual;
      }

      var compareValue = expression.GetValue<string>();
      if (compareValue == _value)
      {
        return EqualityFlag.Equal;
      }

      return EqualityFlag.NotEqual;
    }

    public void Add(IExpression expression)
    {
      _value += expression.GetValue<string>();
    }

    public void Subtract(IExpression expression)
    {
    }

    public void Multiply(IExpression expression)
    {
    }

    public void Divide(IExpression expression)
    {
    }

    #endregion

    public override string ToString()
    {
      return $"{DataType}[{_value}]";
    }
  }
}