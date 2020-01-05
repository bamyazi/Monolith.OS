using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser
{
  public class Argument
  {
    public ArgumentType ArgumentType { get; private set; }
    public int Value { get; private set; }
    internal string Label { get; private set; }
    internal void ReplaceLabel(int value)
    {
      Value = value;
    }

    public Argument(assemblerParser.ArgumentContext context)
    {
      var number = context.number();
      var address = context.address();
      var register = context.register();
      var indirectRegister = context.indirectregister();
      var label = context.label();

      if (number != null)
      {
        ArgumentType = ArgumentType.Value;
        Value = int.Parse(number.NUMBER().GetText());
      }
      else if (address != null)
      {
        ArgumentType = ArgumentType.Address;
        Value = int.Parse(address.number().NUMBER().GetText());
      }
      else if (register != null)
      {
        ArgumentType = ArgumentType.Register;
        var registerEnum = Enum.Parse(typeof(Register), register.REGISTER().GetText());
        Value = (int)registerEnum;
      }
      else if (indirectRegister != null)
      {
        ArgumentType = ArgumentType.IndirectRegister;
        var registerEnum = Enum.Parse(typeof(Register), indirectRegister.register().REGISTER().GetText());
        Value = (int)registerEnum;
      }
      else if (label != null)
      {
        ArgumentType = ArgumentType.Value;
        Label = label.name().GetText();
      }
    }
  }
}
