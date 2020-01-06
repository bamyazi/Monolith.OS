using Monolith.VM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Compiler
{
  public interface ICompiler
  {
    Program Compile(string sourceCode);
  }
}
