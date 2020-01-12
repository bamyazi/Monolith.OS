﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Monolith.VM.Compiler.Instructions;
using Monolith.VM.Exceptions;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler
{
  public static class InstructionFactory
  {
    public static IInstruction BuildInstruction(OpCode opCode, MonoLangParser.OperationContext context)
    {
      switch (opCode)
      {
        case OpCode.BEGIN_SCOPE:
          return new BEGIN_SCOPE_Instruction();
        case OpCode.END_SCOPE:
          return new END_SCOPE_Instruction();
        case OpCode.ASSIGN:
          return new ASSIGN_Instruction(context.var(), context.expression());
        case OpCode.COMPARE:
          return new COMPARE_Instruction(context.expression());
        case OpCode.ADD:
          return new ADD_Instruction(context.var(), context.expression());       
        case OpCode.SUBTRACT:
          return new SUBTRACT_Instruction(context.var(), context.expression());
        case OpCode.MULTIPLY:
          return new MULTIPLY_Instruction(context.var(), context.expression());
        case OpCode.DIVIDE:
          return new DIVIDE_Instruction(context.var(), context.expression());
        case OpCode.PUSH:
          return new PUSH_Instruction(context.expression());
        case OpCode.POP:
          return new POP_Instruction(context.var());
        case OpCode.JUMP:
          return new JUMP_Instruction(context.address());
        case OpCode.JUMP_EQUAL:
          return new JUMP_EQUAL_Instruction(context.address());
        case OpCode.JUMP_NOT_EQUAL:
          return new JUMP_NOT_EQUAL_Instruction(context.address());
        case OpCode.JUMP_LESS_THAN:
          return new JUMP_LESS_THAN_Instruction(context.address());
        case OpCode.JUMP_GREATER_THAN:
          return new JUMP_GREATER_THAN_Instruction(context.address());
        case OpCode.CALL:
          return new CALL_Instruction(context.address());
        case OpCode.RETURN:
          return new RETURN_Instruction();
        case OpCode.WRITE:
          return new WRITE_Instruction(context.port(), context.expression());
        case OpCode.READ:
          return  new READ_Instruction(context.port(), context.var());
        case OpCode.EXEC:
          return new EXEC_Instruction();
        case OpCode.LOCK:
          return new LOCK_Instruction();
        case OpCode.RELEASE:
          return new RELEASE_Instruction();
        case OpCode.WAIT:
          return new WAIT_Instruction();
        case OpCode.EXIT:
          return new EXIT_Instruction(context.expression());
        default:
          throw new InvalidInstructionException(opCode);
      }
    }
  }
}
