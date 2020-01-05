using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser
{
  public class Instruction
  {
    public uint Address { get; private set; }
    public OpCode OpCode { get; private set; }
    public Argument[] Arguments { get; private set; }

    public Instruction(uint address, assemblerParser.OperationContext context)
    {
      Address = address;
      var text = context.GetText();
      var opCode = context.opcode().GetText();
      OpCode = (OpCode) Enum.Parse(typeof(OpCode), opCode);
      var argumentsContext = context.arguments();
      if (argumentsContext != null)
      {
        var arguments = argumentsContext.argument();
        Arguments = new Argument[arguments.Length];
        for (int i = 0; i < arguments.Length; i++)
        {
          Arguments[i] = new Argument(arguments[i]);
        }
      }
    }
  }
}
