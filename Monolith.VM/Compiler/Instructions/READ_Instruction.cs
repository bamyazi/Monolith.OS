using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class READ_Instruction : BaseInstruction
  {
    private string _portName;
    private IVariable _variable;

    public READ_Instruction(MonoLangParser.PortContext portContext, MonoLangParser.VarContext varContext)
    {
      _portName = portContext.name().NAME().GetText();
      _variable = VariableFactory.BuildVariable(varContext);
    }

    public override void Execute(ProcessContext context)
    {
      if (_variable is NamedVariable namedVariable)
      {
        namedVariable.SetProcess(context);
      }
      var device = context.GetDevice(_portName);
      _variable.SetValue(device.Read());
    }
  }
}
