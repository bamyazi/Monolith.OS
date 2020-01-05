using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.OS.Parser
{
  public class AssemblyCodeCompilerVisitor : assemblerBaseVisitor<Instruction[]>
  {
    public uint _address = 0;
    public Dictionary<string, int> _labels = new Dictionary<string, int>();

    public override Instruction[] VisitLabel(assemblerParser.LabelContext context)
    {
      var labelName = context.name().NAME().GetText();
      _labels.Add(labelName, (int) _address);
      return null;
    }

    public override Instruction[] VisitProg(assemblerParser.ProgContext context)
    {
      List<Instruction> instructions = new List<Instruction>();
      foreach (var lineContext in context.line())
      {
        var childInstructions = VisitChildren(lineContext);
        if (childInstructions==null) continue;
        instructions.AddRange(childInstructions);
      }
      // Replace labels
      foreach (var instruction in instructions)
      {
        if (instruction.Arguments != null)
        {
          foreach (var argument in instruction.Arguments)
          {
            if (argument.ArgumentType == ArgumentType.Value && argument.Label != null)
            {
              argument.ReplaceLabel(_labels[argument.Label]);
            }
          }
        }
      }
      return instructions.ToArray();
    }

    public override Instruction[] VisitInstruction(assemblerParser.InstructionContext context)
    {
      return VisitOperation(context.operation());
    }

    public override Instruction[] VisitOperation(assemblerParser.OperationContext context)
    {
      var result = new Instruction(_address, context);
      _address ++;
      return new [] { result };
    }
  }
}
