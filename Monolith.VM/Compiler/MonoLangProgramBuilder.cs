using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler
{
  public class MonoLangProgramBuilder : MonoLangBaseListener
  {
    public  Program Program { get; private set; }
    private Dictionary<string, uint> _labels;
    private uint _instructionIndex = 0;
    private List<IInstruction> _instructions;

    public MonoLangProgramBuilder()
    {
      Program = new Program();
      _labels = new Dictionary<string, uint>();
      _instructionIndex = 0;
      _instructions = new List<IInstruction>();
    }

    public override void ExitProg(MonoLangParser.ProgContext context)
    {
      Program.Load(_instructions.ToArray());
      base.ExitProg(context);
    }

    public override void ExitInstruction(MonoLangParser.InstructionContext context)
    {
      var operation = context.operation();
      var instructionName = operation.children[0].GetText();
      var opCode = (OpCode) Enum.Parse(typeof(OpCode), instructionName.ToUpper());
      _instructions.Add(InstructionFactory.BuildInstruction(opCode, operation));
      base.ExitInstruction(context);
    }

    public override void ExitLabel(MonoLangParser.LabelContext context)
    {
      var labelName = context.name().NAME().GetText();
      if (!_labels.ContainsKey(labelName))
      {
        _labels.Add(labelName, _instructionIndex);
      }
      else
      {
        throw new CompilationExcetion(
          CompilationExcetion.DUPLICATE_LABEL,
          context.Start.Line, context.Start.Column);
      }
      base.EnterLabel(context);
    }
  }
}
