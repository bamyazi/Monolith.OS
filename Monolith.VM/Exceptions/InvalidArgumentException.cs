using System;
using System.Collections.Generic;
using System.Text;
using Monolith.VM.Model;

namespace Monolith.VM
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
