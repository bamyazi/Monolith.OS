using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  public class CALL_Instruction : BaseInstruction
  {
    public override void Execute(ProcessContext context, Argument[] arguments)
    {
      var destination = arguments[0];
      context.Stack.Push(context.InstructionPointer);
      // Set instruction pointer to target - 1, since it will be incremented after the instruction executes
      context.InstructionPointer = ((int)GetValue(context, destination))-1;
    }
  }
}
