using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  internal class MOV_Instuction : BaseInstruction
  {
    public override void Execute(ProcessContext context, Argument[] arguments)
    {
      var destination = arguments[0];
      var source = arguments[1];

      var sourceValue = GetValue(context, source);
      SetValue(context, destination, sourceValue);
    }
  }
}
