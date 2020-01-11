using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Test
{
  public class TestDevice : IDevice
  {
    public void Write<T>(T value)
    {
      Debug.WriteLine(value.ToString());
    }
  }
}
