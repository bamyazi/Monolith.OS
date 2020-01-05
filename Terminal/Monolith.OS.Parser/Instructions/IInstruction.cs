using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  public interface IInstruction
  {
    void Execute(ProcessContext context, Argument[] arguments);
  }
}
