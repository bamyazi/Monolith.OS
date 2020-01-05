using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monolith.OS.Test
{
  [TestClass]
  public class ADD_InstructionTests
  {
    [TestMethod]
    public void AddValueToRegister()
    {
      var process = ProgramLoader.Load("ADD_AddValueToRegister.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[0], 11);
    }

    [TestMethod]
    public void AddRegisterToRegister()
    {
      var process = ProgramLoader.Load("ADD_AddRegisterToRegister.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[0], 110);
    }

    [TestMethod]
    public void AddIndirectRegisterToRegister()
    {
      var process = ProgramLoader.Load("ADD_AddIndirectRegisterToRegister.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[0], 110);
    }

    [TestMethod]
    public void AddNegativeValueToRegister()
    {
      var process = ProgramLoader.Load("ADD_AddNegativeValueToRegister.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[0], 9);
    }
  }
}
