using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monolith.OS.Test
{
  [TestClass]
  public class CMP_InstructionTests
  {
    [TestMethod]
    public void CompareRegisterToValue()
    {
      var process = ProgramLoader.LoadAssembly("CMP_CompareRegisterToValue.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(true, process.LessFlag);
    }
  }
}
