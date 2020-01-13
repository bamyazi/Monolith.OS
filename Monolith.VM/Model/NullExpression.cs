using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class NullExpression : IExpression
  {
    public DataType DataType { get; }
    public T GetValue<T>()
    {
      return default(T);
    }

    public EqualityFlag Compare(IExpression expression)
    {
      return expression is NullExpression ? EqualityFlag.Equal : EqualityFlag.NotEqual;
    }

    public void Add(IExpression expression)
    {
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

    public IExpression Clone()
    {
      return new NullExpression();
    }
  }
}
