using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Compiler.Instructions
{
  public interface ILabeledInstruction
  {
    string LabelName { get; }
    void ReplaceLabel(uint value);
  }
}
