﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public abstract class BaseInstruction : IInstruction
  {
    public abstract void Execute(ProcessContext context);
  }
}
