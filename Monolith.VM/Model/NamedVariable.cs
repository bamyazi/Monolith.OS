using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class NamedVariable : IVariable, IExpression
  {
    public string Name { get; private set; }

    private DataType _dataType;
    public DataType DataType => _dataType;
    public NamedVariable(string name)
    {
      Name = name;
    }

    public IExpression Clone()
    {
      return this;
    }

    public T GetValue<T>(ProcessContext context)
    {
      var expression = context.Data.GetValue(Name);
      return expression.GetValue<T>(context);
    }

    public void SetValue(ProcessContext context, IExpression value)
    {
      _dataType = value.DataType;
      context.Data.SetValue(Name, value);
    }

    public EqualityFlag Compare(ProcessContext context, IExpression expression)
    {
      var valueExpression = context.Data.GetValue(Name);
      return valueExpression.Compare(context, expression);
    }

    public void Add(ProcessContext context, IExpression expression)
    {
      var valueExpression = context.Data.GetValue(Name);
      valueExpression.Add(context, expression);
    }

    public void Subtract(ProcessContext context, IExpression expression)
    {
      var valueExpression = context.Data.GetValue(Name);
      valueExpression.Subtract(context, expression);
    }

    public void Multiply(ProcessContext context, IExpression expression)
    {
      var valueExpression = context.Data.GetValue(Name);
      valueExpression.Multiply(context, expression);
    }

    public void Divide(ProcessContext context, IExpression expression)
    {
      var valueExpression = context.Data.GetValue(Name);
      valueExpression.Divide(context, expression);
    }

    public override string ToString()
    {
      return $"{Name}";
    }
  }
}
