using System;

namespace Monolith.VM.Model
{
  public class StringLiteral : IExpression
  {
    private string _value;

    public StringLiteral(string value)
    {
      _value = value;
    }

    public IExpression Clone()
    {
      return new StringLiteral(_value);
    }

    #region IExpression Members

    public DataType DataType => DataType.String;

    public T GetValue<T>(ProcessContext context)
    {
      var castType = typeof(T);
      return (T) Convert.ChangeType(_value, castType);
    }

    public EqualityFlag Compare(ProcessContext context, IExpression expression)
    {
      if (expression.DataType != DataType.String)
      {
        return EqualityFlag.NotEqual;
      }

      var compareValue = expression.GetValue<string>(context);
      if (compareValue == _value)
      {
        return EqualityFlag.Equal;
      }

      return EqualityFlag.NotEqual;
    }

    public void Add(ProcessContext context, IExpression expression)
    {
      _value += expression.GetValue<string>(context);
    }

    public void Subtract(ProcessContext context, IExpression expression)
    {
      throw new NotImplementedException();
    }

    public void Multiply(ProcessContext context, IExpression expression)
    {
      throw new NotImplementedException();
    }

    public void Divide(ProcessContext context, IExpression expression)
    {
      throw new NotImplementedException();
    }

    #endregion

    public override string ToString()
    {
      return $"{DataType}[{_value}]";
    }
  }
}