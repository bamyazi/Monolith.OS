using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public enum OpCode : byte
  {
    BEGIN_SCOPE,
    END_SCOPE,
    ASSIGN,
    COMPARE,
    ADD,
    SUBTRACT,
    MULTIPLY,
    DIVIDE,
    PUSH,
    POP,
    JUMP,
    JUMP_EQUAL,
    JUMP_NOT_EQUAL,
    JUMP_LESS_THAN,
    JUMP_GREATER_THAN,
    CALL,
    RETURN,
    WRITE,
    READ,
    EXEC,
    LOCK,
    RELEASE,
    WAIT,
    EXIT
  }
}
