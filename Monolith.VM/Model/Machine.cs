using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class Machine
  {
    private uint _processIndex = 1000;

    private Dictionary<uint, ProcessContext> _processes = new Dictionary<uint, ProcessContext>();
    public Machine()
    {

    }

    public ProcessContext CreateProcess()
    {
      var process = new ProcessContext(this, _processIndex);
      _processIndex++;
      return process;
    }

    public void Tick()
    {

    }
  }
}
