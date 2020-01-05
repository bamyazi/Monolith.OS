using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser
{
  public enum ArgumentType : byte
  {
    Value,
    Address,
    Register,
    IndirectRegister
  }
}
