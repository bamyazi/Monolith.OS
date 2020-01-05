using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Monolith.OS.Parser.Instructions
{
  public abstract class BaseInstruction : IInstruction
  {
    public abstract void Execute(ProcessContext context, Argument[] arguments);

    protected int GetValue(ProcessContext context, Argument argument)
    {
      switch (argument.ArgumentType)
      {
       case ArgumentType.Address:
         return context.ProcessMemory[argument.Value];
       case ArgumentType.Register:
         return context.Registers[argument.Value];
       case ArgumentType.Value:
         return argument.Value;
       case ArgumentType.IndirectRegister:
         return context.ProcessMemory[context.Registers[argument.Value]];
       default:
         throw new InvalidArgumentException(argument);
      }
    }

    public void SetValue(ProcessContext context, Argument argument, int value)
    {
      switch (argument.ArgumentType)
      {
        case ArgumentType.Address:
          context.ProcessMemory[argument.Value] = value;
          break;
        case ArgumentType.Register:
          context.Registers[argument.Value] = value;
          break;
        case ArgumentType.IndirectRegister:
          context.ProcessMemory[context.Registers[argument.Value]] = value;
          break;
        default:
          throw new InvalidArgumentException(argument);
      }
    }
  }
}
