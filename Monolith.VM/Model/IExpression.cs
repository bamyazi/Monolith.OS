using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public interface IExpression 
  {
    DataType DataType { get; }
    T GetValue<T>();
    EqualityFlag Compare(IExpression expression);
    void Add(IExpression expression);
    void Subtract(IExpression expression);
    void Multiply(IExpression expression);
    void Divide(IExpression expression);
    IExpression Clone();
  }
}
