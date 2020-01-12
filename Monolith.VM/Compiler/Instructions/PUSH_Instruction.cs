using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class PUSH_Instruction : BaseInstruction
  {
    private IExpression _expression;
    public PUSH_Instruction(MonoLangParser.ExpressionContext[] expressionContext)
    {
      _expression = ExpressionFactory.BuildExpression(expressionContext[0]);
    }

    public override void Execute(ProcessContext context)
    {
      context.DataStack.Push(_expression);
    }
  }
}
