using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class NumberLiteral : IExpression
  {
    private decimal _value;

    public NumberLiteral(string value)
    {
      _value = decimal.Parse(value);
    }

    public object GetValue(ProcessContext context)
    {
      return _value;
    }
  }
}
