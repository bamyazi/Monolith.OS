using System;
using System.Collections.Generic;
using System.Text;
using Monolith.OS.Parser;

namespace Monolith.OS
{
  public class InvalidArgumentException : Exception
  {
    public Argument Argument { get; private set; }

    public InvalidArgumentException(Argument argument)
    {
      Argument = argument;
    }
  }
}
