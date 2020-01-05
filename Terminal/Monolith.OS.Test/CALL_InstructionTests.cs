using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monolith.OS.Test
{
  [TestClass]
  public class CALL_InstructionTests
  {
    [TestMethod]
    public void JumpToLabel()
    {
      var process = ProgramLoader.Load("CALL_CallToLabel.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(10, process.Registers[(int)Register.AX]);
      Assert.AreEqual(100, process.Registers[(int)Register.BX]);
    }
  }
}
