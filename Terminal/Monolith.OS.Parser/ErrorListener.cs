using System.Diagnostics;
using System.IO;
using Antlr4.Runtime;

namespace Monolith.OS.Parser
{
  public class ErrorListener<S> : ConsoleErrorListener<S>
  {
    public bool had_error;

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, S offendingSymbol, int line,
        int charPositionInLine, string msg, RecognitionException e)
    {
      Debug.WriteLine($"error@{line},{charPositionInLine}");
      Debug.WriteLine(msg);
      had_error = true;
      base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
    }
  }
}