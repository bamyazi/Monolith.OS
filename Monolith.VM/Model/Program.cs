using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public class Program
  {
    public  List<IInstruction> Instructions { get; private set; }

    public void Load(List<IInstruction> instructions)
    {
      Instructions = instructions;
    }
  }
}
