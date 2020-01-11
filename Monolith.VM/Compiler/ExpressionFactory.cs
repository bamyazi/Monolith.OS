using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler
{
  public static class ExpressionFactory
  {
    public static IExpression BuildExpression(MonoLangParser.ExpressionContext context)
    {
      var varExpression = context.var();
      var varPointerExpression = context.var_pointer();
      var literalExpression = context.literal();

      if (varExpression != null)
      {
        return (IExpression) VariableFactory.BuildVariable(varExpression, false);
      }
      else if (varPointerExpression != null)
      {
        return (IExpression) VariableFactory.BuildVariable(varPointerExpression.var(), true);
      }
      else if (literalExpression != null)
      {
        var stringLiteral = literalExpression.string_literal();
        var numberLiteral = literalExpression.number_literal();
        if (stringLiteral != null)
        {
          return new StringLiteral(stringLiteral.STRING().GetText());
        }
        else if (numberLiteral != null)
        {
          var numText = numberLiteral.NUMBER().GetText();
          return new IntLiteral(int.Parse(numText));
        }
      }
      return null;
    }
  }
}
