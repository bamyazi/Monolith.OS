using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser
{
  public enum OpCode : byte
  {
    EXIT,
    NOP,

    MOV,
    ADD,

    CMP,

    JMP,
    JLT,
    JGT,
    JEQ,
    JNE,

    PUSH,
    POP,

    CALL,
    RET,

    INPUT,
    OUTPUT,

    /*
   NOT,
   OR,
   XOR,
   AND,
   NEG,

   ALLOC,
   RELEASE,
   */

  }
}
