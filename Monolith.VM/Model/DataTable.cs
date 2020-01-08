using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class DataTable
  {
    private Dictionary<string, IExpression> _data = new Dictionary<string, IExpression>();

    public void SetValue(string name, IExpression value)
    {
      _data[name] = value;
    }

    public IExpression GetValue(string name)
    {
      return _data[name];
    }
  }
}
