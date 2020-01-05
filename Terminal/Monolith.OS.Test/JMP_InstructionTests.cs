using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monolith.OS.Parser;

namespace Monolith.OS.Test
{
  [TestClass]
  public class JMP_InstructionTests
  {
    [TestMethod]
    public void JumpToLabel()
    {
      var process = ProgramLoader.Load("JMP_JumpToLabel.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(10, process.Registers[(int)Register.AX]);
    }

    [TestMethod]
    public void JumpLessThanToLabel()
    {
      var process = ProgramLoader.Load("JMP_JumpLessThanToLabel.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(10, process.Registers[(int)Register.AX]);
      Assert.AreEqual(100, process.Registers[(int)Register.BX]);
    }
  }
}
