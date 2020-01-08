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
    T GetValue<T>(ProcessContext context);
    EqualityFlag Compare(ProcessContext context, IExpression expression);
    void Add(ProcessContext context, IExpression expression);
    void Subtract(ProcessContext context, IExpression expression);
    void Multiply(ProcessContext context, IExpression expression);
    void Divide(ProcessContext context, IExpression expression);
    IExpression Clone();
  }
}
