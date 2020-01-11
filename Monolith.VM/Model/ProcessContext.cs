using System;
using System.Collections.Generic;

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
    public bool Terminated { get; set; }
    public IExpression ExitCode { get; set; }
    public EqualityFlag EqualityFlag { get; internal set; }

    private Dictionary<string,IDevice> _devices { get; set; } = new Dictionary<string, IDevice>();

    #region IProcess Members

    public Priority Priority { get; set; }

    public void Tick(float dt)
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

    public void RegisterDevice(string name, IDevice device)
    {
      _devices.Add(name, device);
    }

    public IDevice GetDevice(string name)
    {
      return _devices[name.ToUpper()];
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