using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  public class POP_Instruction : BaseInstruction
  {
    public override void Execute(ProcessContext context, Argument[] arguments)
    {
      var destination = arguments[0];

      SetValue(context, destination, context.Stack.Pop());
    }
  }
}
