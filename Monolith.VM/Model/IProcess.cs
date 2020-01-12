using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public interface IProcess
  {
    uint ProcessId { get; }
    Priority Priority { get; set; }
    void Tick(float dt);
    void LoadProgram(Program program);
    bool Terminated { get; set; }
    IExpression ExitCode { get; set; }

    IDevice GetDevice(string name);
    void RegisterDevice(string name, IDevice device);
    Stack<uint> AddressStack { get; }
  }
}
