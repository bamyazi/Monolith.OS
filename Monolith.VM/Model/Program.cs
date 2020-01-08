﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class Program
  {
    public  IInstruction[] Instructions { get; private set; }

    public void Load(IInstruction[] instructions)
    {
      Instructions = instructions;
    }
  }
}
