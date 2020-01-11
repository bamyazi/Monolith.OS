using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Compiler.Instructions;

namespace Monolith.VM.Model
{
  public class Machine
  {
    private uint _processIndex = 1000;
    public static IInstruction[] InstructionSet = LoadInstructions() ;

    private Dictionary<uint, ProcessContext> _processes = new Dictionary<uint, ProcessContext>();

    private static IInstruction[] LoadInstructions()
    {
      // Instructions in this array need to be defined in the same order
      // as the OpCode enum.
      return new IInstruction[]
      {

      };
    }

    public Machine()
    {

    }

    public IProcess CreateProcess()
    {
      var process = new ProcessContext(this, _processIndex);
      _processes.Add(_processIndex, process);
      _processIndex++;
      return process;
    }

    private List<IProcess> _terminatedProcesses = new List<IProcess>();
    public void Tick(float dt)
    {
      _terminatedProcesses.Clear();
      foreach (var process in _processes.Values)
      {
        if (!process.Terminated)
        {
          process.Tick(dt);
        }
        else
        {
          _terminatedProcesses.Add(process);
        }
      }

      foreach (var process in _terminatedProcesses)
      {
        _processes.Remove(process.ProcessId);
      }
    }
  }
}
