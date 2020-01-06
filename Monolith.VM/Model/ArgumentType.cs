using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.VM.Model
{
  public enum ArgumentType : byte
  {
    Variable,
    String,
    Number,
    List,
  }
}
