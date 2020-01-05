using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monolith.OS.Test
{
  [TestClass]
  public class EXIT_InstructionTests
  {
    [TestMethod]
    public void ExitValue()
    {
      var process = ProgramLoader.LoadAssembly("EXIT_ExitValue.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.ExitCode, 12345);
    }
  }
}
