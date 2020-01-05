using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  internal class ADD_Instruction : BaseInstruction
  {
    public override void Execute(ProcessContext context, Argument[] arguments)
    {
      var destination = arguments[0];
      var source = arguments[1];

      var destValue = GetValue(context, destination);
      var sourceValue = GetValue(context, source);

      SetValue(context, destination, destValue + sourceValue);
    }
  }
}
