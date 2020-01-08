using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class Index
  {
    public uint Start { get; private set; }
    public uint End { get; private set; }

    public Index(uint start, uint end)
    {
      Start = start;
      End = end;
    }
  }
}
