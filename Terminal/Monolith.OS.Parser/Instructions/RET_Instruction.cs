using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  public class RET_Instruction : BaseInstruction
  {
    public override void Execute(ProcessContext context, Argument[] arguments)
    {
      // Set instruction pointer to target - 1, since it will be incremented after the instruction executes
      context.InstructionPointer = context.Stack.Pop();
    }
  }
}
