using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monolith.OS.Parser;
using Monolith.OS.Parser.Compiler;

namespace Monolith.OS.Test.Programs
{
  [TestClass]
  public class MOV_InstructionTests
  {
    [TestMethod]
    public void LoadRegisterFromValueTest()
    {
      var process = ProgramLoader.LoadAssembly("MOV_LoadRegisterFromValue.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[(int)Register.AX], 12345);
    }

    [TestMethod]
    public void LoadRegisterFromRegisterTest()
    {
      var process = ProgramLoader.LoadAssembly("MOV_LoadRegisterFromRegister.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[(int)Register.AX], process.Registers[(int)Register.BX]);
    }

    [TestMethod]
    public void LoadRegisterFromMemoryTest()
    {
      var process = ProgramLoader.LoadAssembly("MOV_LoadRegisterFromMemory.asm");
      process.ProcessMemory[0] = 12345;
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[(int)Register.AX], 12345);
    }

    [TestMethod]
    public void LoadRegisterFromIndirectRegister()
    {
      var process = ProgramLoader.LoadAssembly("MOV_LoadRegisterFromIndirectRegister.asm");
      process.ProcessMemory[0] = 1000;
      process.ProcessMemory[1000] = 12345;
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.Registers[(int)Register.BX], 12345);
    }

    [TestMethod]
    public void LoadMemoryFromValue()
    {
      var process = ProgramLoader.LoadAssembly("MOV_LoadMemoryFromValue.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.ProcessMemory[0], 12345);
    }

    [TestMethod]
    public void LoadMemoryFromRegister()
    {
      var process = ProgramLoader.LoadAssembly("MOV_LoadMemoryFromRegister.asm");
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.ProcessMemory[0], 12345);
    }

    [TestMethod]
    public void LoadMemoryFromIndirectRegister()
    {
      var process = ProgramLoader.LoadAssembly("MOV_LoadMemoryFromIndirectRegister.asm");
      process.ProcessMemory[1] = 12345;
      while (!process.Exited)
      {
        process.Tick();
      }
      Assert.AreEqual(process.ProcessMemory[2], 12345);
    }
  }
}
