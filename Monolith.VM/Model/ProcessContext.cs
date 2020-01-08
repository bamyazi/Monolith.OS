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

    public bool Terminated { get; internal set; }
    public IExpression ExitCode { get; internal set; }
    public EqualityFlag EqualityFlag { get; internal set; }

    #region IProcess Members

    public Priority Priority { get; set; }

    public void Tick()
    {
      var instruction = Program.Instructions[InstructionPointer];
      instruction.Execute(this);
      if (Terminated) return;
      InstructionPointer++;
      if (InstructionPointer >= Program.Instructions.Length)
      {
        Terminated = true;
        //todo: Handle unexpected terminiation
      }
    }

    #endregion

    public void LoadProgram(Program program)
    {
      Program = program;
      InstructionPointer = 0;
      Terminated = false;
    }

    public void Jump(uint address)
    {
      InstructionPointer = address - 1;
    }
  }
}