using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.VM
{
  public class CompilationExcetion : Exception
  {
    public const string DUPLICATE_LABEL = "Duplicate label";

    private int _sourceLine;
    private int _sourceChar;

    public CompilationExcetion(string message, int sourceLine, int sourceChar)
      : base(message)
    {
      _sourceLine = sourceLine;
      _sourceChar = sourceChar;
    }
  }
}
