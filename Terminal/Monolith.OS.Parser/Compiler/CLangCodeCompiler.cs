using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;

namespace Monolith.OS.Parser.Compiler
{
  public class CLangCodeCompiler
  {
    public Instruction[] Compile(string sourceCode)
    {
      var inputStream = new AntlrInputStream(sourceCode);
      var lexer = new clangLexer(inputStream);
      var tokens = new CommonTokenStream(lexer);
      var parser = new clangParser(tokens);
      var errorListener = new ErrorListener<IToken>();
      parser.AddErrorListener(errorListener);
      var tree = parser.primaryExpression();
      if (errorListener.had_error)
      {
        throw new CompilationExcetion();
      }

      return null;
    }
  }
}
