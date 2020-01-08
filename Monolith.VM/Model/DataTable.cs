using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class DataTable
  {
    private Dictionary<string, object> _data = new Dictionary<string, object>();

    public void SetValue(string name, object value)
    {
      _data[name] = value;
    }

    public object GetValue(string name)
    {
      return _data[name];
    }
  }
}
