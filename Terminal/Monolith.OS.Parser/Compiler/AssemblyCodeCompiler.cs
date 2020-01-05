using Antlr4.Runtime;

namespace Monolith.OS.Parser.Compiler
{
  public class AssemblyCodeCompiler
  {
    public Instruction[] Compile(string sourceCode)
    {
      var inputStream = new AntlrInputStream(sourceCode);
      var lexer = new assemblerLexer(inputStream);
      var tokens = new CommonTokenStream(lexer);
      var parser = new assemblerParser(tokens);
      var errorListener = new ErrorListener<IToken>();
      parser.AddErrorListener(errorListener);
      var tree = parser.prog();
      if (errorListener.had_error)
      {
        throw new CompilationExcetion();
      }

      var visitor = new AssemblyCodeCompilerVisitor();
      return visitor.Visit(tree);
    }
  }
}