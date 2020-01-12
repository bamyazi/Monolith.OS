using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class POP_Instruction : BaseInstruction
  {
    private IVariable _variable;

    public POP_Instruction(MonoLangParser.VarContext varContext)
    {
      _variable = VariableFactory.BuildVariable(varContext);
    }

    public override void Execute(ProcessContext context)
    {
      if (_variable is NamedVariable namedVariable)
      {
        namedVariable.SetProcess(context);
      }
      var expression = context.DataStack.Pop();
      _variable.SetValue(expression.Clone());
    }
  }
}
