using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class WRITE_Instruction : BaseInstruction
  {
    private string _portName;
    private IExpression _outputExpression;

    public WRITE_Instruction(MonoLangParser.PortContext portContext, MonoLangParser.ExpressionContext[] expressionContext)
    {
      _portName = portContext.name().NAME().GetText();
      _outputExpression = ExpressionFactory.BuildExpression(expressionContext[0]);
    }

    public override void Execute(ProcessContext context)
    {
      if (_outputExpression is NamedVariable namedExpression)
      {
        namedExpression.SetProcess(context);
      }
      var device = context.GetDevice(_portName);
      device.Write(_outputExpression);
    }
  }
}
