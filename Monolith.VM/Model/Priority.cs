﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public enum Priority : byte
  {
    Idle,
    Low,
    Medium,
    High,
    System
  }
}
