using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monolith.OS.Test.CLangCode
{
  [TestClass]
  public class CLANG_HelloWorld
  {
    [TestMethod]
    public void HelloWorld()
    {
      var process = ProgramLoader.LoadCLang("CLANG_HelloWorld.c");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.ExitCode, 12345);
    }
  }
}
