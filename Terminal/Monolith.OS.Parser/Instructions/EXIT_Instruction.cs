using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  internal class EXIT_Instruction : BaseInstruction
  {
    public override void Execute(ProcessContext context, Argument[] arguments)
    {
      context.Exited = true;
      var source = arguments[0];
      context.ExitCode = GetValue(context, source);
    }
  }
}
