using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
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
      if (_leftExpression is NamedVariable namedLeftExpression)
      {
        namedLeftExpression.SetProcess(context);
      }
      if (_rightExpression is NamedVariable namedRightExpression)
      {
        namedRightExpression.SetProcess(context);
      }
      context.EqualityFlag = _leftExpression.Compare(_rightExpression);

    }
  }
}
