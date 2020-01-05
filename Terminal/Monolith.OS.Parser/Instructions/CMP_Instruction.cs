using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  public class CMP_Instruction : BaseInstruction
  {
    public override void Execute(ProcessContext context, Argument[] arguments)
    {
      var destination = arguments[0];
      var source = arguments[1];

      var destValue = GetValue(context, destination);
      var sourceValue = GetValue(context, source);

      if (destValue == sourceValue)
      {
        context.LessFlag = false;
        context.GreaterFlag = false;
        context.EqualFlag = true;
      }
      else if (destValue < sourceValue)
      {
        context.LessFlag = true;
        context.GreaterFlag = false;
        context.EqualFlag = false;
      }
      else if (destValue > sourceValue)
      {
        context.LessFlag = false;
        context.GreaterFlag = true;
        context.EqualFlag = false;
      }
    }
  }
}
