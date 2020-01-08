using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Compiler.Instructions
{
  public class JUMP_EQUAL_Instruction : BaseInstruction, ILabeledInstruction
  {
    private MonoLangParser.NameContext _nameContext;
    private uint _address;
    public JUMP_EQUAL_Instruction(MonoLangParser.AddressContext context)
    {
      _nameContext = context.name();
      _address = context.NUMBER() != null ? uint.Parse(context.NUMBER().GetText()) : 0;
    }

    public override void Execute(ProcessContext context)
    {
      if (context.EqualityFlag != EqualityFlag.Equal) return;
      context.Jump(_address);
    }

    public string LabelName => _nameContext?.GetText();
    public void ReplaceLabel(uint value)
    {
      if (_nameContext != null)
      {
        _address = value;
      }
    }
  }
}
