using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monolith.OS.Test;
using Monolith.VM.Model;

namespace Monolith.VM.Test
{
  [TestClass]
  public class MonoLangCompilerTests
  {
    [TestMethod]
    public void TestCompile()
    {
      var program = ProgramLoader.Load("CompilerTest.mvm");

      var machine = new Machine();
      var process = machine.CreateProcess();
      process.LoadProgram(program);
    }
  }
}
