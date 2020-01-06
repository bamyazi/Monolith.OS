using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Monolith.OS.Parser.Compiler;

namespace Monolith.OS.Test
{
  public static class ProgramLoader
  {
    private static string LoadSourceCode(string name)
    {
      using(var streamReader = new StreamReader(
        Assembly.GetExecutingAssembly().GetManifestResourceStream($"Monolith.OS.Test.Programs.{name}")))
      {
        return streamReader.ReadToEnd();
      }
    }

    public static ProcessContext LoadAssembly(string name)
    {
      var sourceCode = LoadSourceCode(name);
      var compiler = new AssemblyCodeCompiler();
      var program = compiler.Compile(sourceCode);
      ProcessContext process = new ProcessContext();
      process.LoadProgram(program);
      return process;
    }
  }
}
