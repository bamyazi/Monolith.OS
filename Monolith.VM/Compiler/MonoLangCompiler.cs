using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler
{
  public class MonoLangCompiler : ICompiler
  {
    public Program Compile(string sourceCode)
    {
      var inputStream = new AntlrInputStream(sourceCode);
      var lexer = new MonoLangLexer(inputStream);
      var tokens = new CommonTokenStream(lexer);
      var parser = new MonoLangParser(tokens);
      var errorListener = new ErrorListener<IToken>();
      parser.AddErrorListener(errorListener);
      var tree = parser.prog();
      if (errorListener.had_error)
      {
        throw new CompilationExcetion();
      }
      
      Debug.WriteLine(Output.OutputTokens(tokens.GetTokens()));
      //var visitor = new AssemblyCodeCompilerVisitor();
      //return visitor.Visit(tree);
      return null;
    }
  }
}
