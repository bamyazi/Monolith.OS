using System;
using System.Collections;
using System.Collections.Generic;
using Monolith.OS.Parser;
using Monolith.OS.Parser.Instructions;

namespace Monolith.OS
{
  public static class CPU
  {
    public const int REGISTER_COUNT = 10;
    public const int PROCESS_MEMORY_SIZE = 16384;

    public static IInstruction[] InstructionSet = LoadInstructions() ;

    private static IInstruction[] LoadInstructions()
    {
      // Instructions in this array need to be defined in the same order
      // as the OpCode enum.
      return new IInstruction[]
      {
        new EXIT_Instruction(), 
        new NOP_Instruction(), 
        new MOV_Instuction(), 
        new ADD_Instruction(), 
        new CMP_Instruction(), 
        new JMP_Instruction(), 
        new JLT_Instruction(), 
        new JGT_Instruction(), 
        new JEQ_Instruction(), 
        new JNE_Instruction(), 
        new PUSH_Instruction(), 
        new POP_Instruction(), 
        new CALL_Instruction(), 
        new RET_Instruction(), 
        new INPUT_Instruction(), 
        new OUTPUT_Instruction(), 
      };
    }
  }
}
