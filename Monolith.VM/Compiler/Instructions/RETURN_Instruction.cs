using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class RETURN_Instruction : BaseInstruction
  {
    public override void Execute(ProcessContext context)
    {
      uint address = context.AddressStack.Pop();
      context.Jump(address + 1);
    }
  }
}
