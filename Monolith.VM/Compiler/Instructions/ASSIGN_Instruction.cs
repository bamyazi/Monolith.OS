using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class ASSIGN_Instruction : BaseInstruction
  {
    private IVariable _variable;
    private IExpression _expression;

    public ASSIGN_Instruction(MonoLangParser.VarContext varContext, MonoLangParser.ExpressionContext[] expressionContext)
    {
      _variable = VariableFactory.BuildVariable(varContext);
      _expression = ExpressionFactory.BuildExpression(expressionContext[0]);
    }

    public override void Execute(ProcessContext context)
    {
      _variable.SetValue(context, _expression.GetValue(context));
    }
  }
}
