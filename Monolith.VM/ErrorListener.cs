﻿using System.Diagnostics;
using System.IO;
using Antlr4.Runtime;

namespace Monolith.VM
{
  public class ErrorListener<S> : ConsoleErrorListener<S>
  {
    public bool had_error;

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, S offendingSymbol, int line,
        int charPositionInLine, string msg, RecognitionException e)
    {
      had_error = true;
      base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);

      Debug.WriteLine("line " + (object) line + ":" + (object) charPositionInLine + " " + msg);
    }
  }
}