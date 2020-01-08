using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class COMPARE_Instruction : BaseInstruction
  {
    private IExpression _leftExpression;
    private IExpression _rightExpression;

    public COMPARE_Instruction(MonoLangParser.ExpressionContext[] context)
    {
      _leftExpression = ExpressionFactory.BuildExpression(context[0]);
      _rightExpression = ExpressionFactory.BuildExpression(context[1]);
    }
    public override void Execute(ProcessContext context)
    {
      var leftValue = _leftExpression.GetValue(context);
      var rightValue = _rightExpression.GetValue(context);

      if (leftValue == rightValue)
        context.EqualityFlag = EqualityFlag.Equal;
      else 
        context.EqualityFlag = EqualityFlag.Less;

    }
  }
}
