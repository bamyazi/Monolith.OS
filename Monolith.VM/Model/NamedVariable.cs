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

    private bool _isPointer;

    private DataType _dataType;
    public DataType DataType => _dataType;

    private IProcess _process;
    public NamedVariable(string name, bool isPointer)
    {
      Name = name;
      _isPointer = isPointer;
    }

    public void SetProcess(IProcess process)
    {
      _process = process;
    }

    public IExpression Clone()
    {
      return this;
    }

    public T GetValue<T>()
    {
      var expression = _process.Data.GetValue(Name);
      return expression.GetValue<T>();
    }

    public void SetValue(IExpression value)
    {
      _dataType = value.DataType;
      _process.Data.SetValue(Name, value);
    }

    public EqualityFlag Compare(IExpression expression)
    {
      var valueExpression = _process.Data.GetValue(Name);
      return valueExpression.Compare(expression);
    }

    public void Add(IExpression expression)
    {
      var valueExpression = _process.Data.GetValue(Name);
      valueExpression.Add(expression);
    }

    public void Subtract(IExpression expression)
    {
      var valueExpression = _process.Data.GetValue(Name);
      valueExpression.Subtract(expression);
    }

    public void Multiply(IExpression expression)
    {
      var valueExpression = _process.Data.GetValue(Name);
      valueExpression.Multiply(expression);
    }

    public void Divide(IExpression expression)
    {
      var valueExpression = _process.Data.GetValue(Name);
      valueExpression.Divide(expression);
    }

    public override string ToString()
    {
      return $"{Name}";
    }
  }
}
