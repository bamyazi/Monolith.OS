using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monolith.OS.Test;

namespace Monolith.VM.Test
{
  [TestClass]
  public class ProgramLoaderTests
  {
    [TestMethod]
    public void TestLoadProgram()
    {
      var program = ProgramLoader.Load("CompilerTest.mvm");
      Assert.IsNotNull(program);
    }
  }
}
