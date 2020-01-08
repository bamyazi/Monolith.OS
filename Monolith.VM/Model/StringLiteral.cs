using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class StringLiteral : IExpression
  {
    private string _value;

    public StringLiteral(string value)
    {
      _value = value;
    }

    public object GetValue(ProcessContext context)
    {
      return _value;
    }
  }
}
