using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class DataTable
  {
    private IProcess _context;
    public DataTable(IProcess context)
    {
      _context = context;
    }

    private Dictionary<string, IExpression> _data = new Dictionary<string, IExpression>();

    public void SetValue(string name, IExpression value)
    {
      _data[name] = value;
    }

    public IExpression GetValue(string name)
    {
      var result = _data[name];
      if (result is NamedVariable namedVariable)
      {
        namedVariable.SetProcess(_context);
      }
      return result;
    }
  }
}
