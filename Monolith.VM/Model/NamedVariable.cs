using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class NamedVariable : IVariable, IExpression
  {
    private string _name;
    public NamedVariable(string name)
    {
      _name = name;
    }

    public object GetValue(ProcessContext context)
    {
      return context.Data.GetValue(_name);
    }

    public void SetValue(ProcessContext context, object value)
    {
      context.Data.SetValue(_name, value);
    }
  }
}
