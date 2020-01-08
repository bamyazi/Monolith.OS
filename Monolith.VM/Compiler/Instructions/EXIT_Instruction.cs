using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class EXIT_Instruction : BaseInstruction
  {
    private IExpression _exitCodeExpression;
    public EXIT_Instruction(MonoLangParser.ExpressionContext[] context)
    {
      _exitCodeExpression = ExpressionFactory.BuildExpression(context[0]);
    }

    public override void Execute(ProcessContext context)
    {
      context.Terminated = true;
      context.ExitCode = _exitCodeExpression;
    }
  }
}
