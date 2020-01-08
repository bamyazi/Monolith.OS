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
      var literalExpression = context.literal();
      if (varExpression != null)
      {
        return (IExpression) VariableFactory.BuildVariable(varExpression);
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
          return new NumberLiteral(numberLiteral.NUMBER().GetText());
        }
      }
      return null;
    }
  }
}
