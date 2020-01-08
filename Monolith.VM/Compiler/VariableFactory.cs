using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler
{
  public static class VariableFactory
  {
    public static IVariable BuildVariable(MonoLangParser.VarContext context)
    {
      var namedVar = context.named_var();
      var indexedVar = context.indexed_var();

      if (namedVar != null)
      {
        return new NamedVariable(namedVar.name().NAME().GetText());
      } 
      else if (indexedVar != null)
      {
        return new IndexedVariable(indexedVar.name().NAME().GetText(), new Index(0,0));
      }
      return null;
    }
  }
}
