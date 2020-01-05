using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monolith.OS.Parser;

namespace Monolith.OS.Test
{
  [TestClass]
  public class PUSH_InstructionTests
  {
    [TestMethod]
    public void PushValueToStack()
    {
      var process = ProgramLoader.LoadAssembly("PUSH_PushValueToStack.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(20, process.Stack.Pop());
      Assert.AreEqual(10, process.Registers[(int)Register.AX]);
    }
  }
}
