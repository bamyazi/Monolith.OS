using System;
using System.Collections.Generic;
using System.Text;
using Monolith.OS.Parser;

namespace Monolith.OS
{
  public class ProcessContext
  {

    public int[] Registers { get; private set; } = new int[(int)Register.COUNT];
    public int[] ProcessMemory { get; private set; } = new int[CPU.PROCESS_MEMORY_SIZE];
    public Instruction[] ProgramMemory { get; private set; }
    public int InstructionPointer { get; internal set; }
    public Stack<int> Stack { get; private set; } = new Stack<int>();

    public bool CarryFlag;
    public bool ZeroFlag;

    public bool LessFlag;
    public bool GreaterFlag;
    public bool EqualFlag;


    public bool Exited { get; internal set; } = false;
    public int ExitCode { get; internal set; }

    public void LoadProgram(Instruction[] programMemory)
    {
      ProgramMemory = programMemory;
      InstructionPointer = 0;
    }

    public void Tick()
    {
      var instruction = ProgramMemory[InstructionPointer];
      Execute(instruction);
      InstructionPointer++;
    }

    public void Execute(Instruction instruction)
    {
      CPU.InstructionSet[(int)instruction.OpCode].Execute(this, instruction.Arguments);
    }
  }
}
