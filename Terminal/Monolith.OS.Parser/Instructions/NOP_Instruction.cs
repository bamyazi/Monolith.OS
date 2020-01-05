using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  internal class NOP_Instruction : IInstruction
  {
    public void Execute(ProcessContext context, Argument[] arguments)
    {
    }
  }
}
