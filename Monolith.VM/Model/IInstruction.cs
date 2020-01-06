using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monolith.VM.Model;

namespace Monolith.VM.Model
{
  public interface IInstruction
  {
    void Execute(ProcessContext context);
  }
}
