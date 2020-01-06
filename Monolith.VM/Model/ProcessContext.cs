using System;

namespace Monolith.VM.Model
{
  public class ProcessContext : IProcess
  {
    internal ProcessContext(Machine machine, uint processId)
    {
      Machine = new Machine();
      ProcessId = processId;
    }

    public uint ProcessId { get; }
    public Machine Machine { get; }
    public DataTable Data { get; } = new DataTable();
    public Program Program { get; private set; }
    public uint InstructionPointer { get; private set; }

    #region IProcess Members

    public Priority Priority { get; set; }

    public void Tick()
    {
    }

    #endregion

    public void LoadProgram(Program program)
    {
      Program = program;
      InstructionPointer = 0;
    }
  }
}