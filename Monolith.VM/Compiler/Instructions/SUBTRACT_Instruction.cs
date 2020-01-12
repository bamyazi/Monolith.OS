using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class SUBTRACT_Instruction : BaseInstruction
  {
    private IVariable _variable;
    private IExpression _expression;

    public SUBTRACT_Instruction(MonoLangParser.VarContext varContext, MonoLangParser.ExpressionContext[] expressionContext)
    {
      _variable = VariableFactory.BuildVariable(varContext);
      _expression = ExpressionFactory.BuildExpression(expressionContext[0]);
    }

    public override void Execute(ProcessContext context)
    {
      if (_variable is NamedVariable namedVariable)
      {
        namedVariable.SetProcess(context);
      }
      if (_expression is NamedVariable namedExpression)
      {
        namedExpression.SetProcess(context);
      }
      var varExpression = context.Data.GetValue((_variable.Name));
      varExpression.Subtract(_expression);

    }
  }
}
