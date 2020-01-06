using System.IO;
using System.Reflection;
using Monolith.VM;
using Monolith.VM.Compiler;
using Monolith.VM.Model;

namespace Monolith.OS.Test
{
  public static class ProgramLoader
  {
    private static string LoadSourceCode(string name)
    {
      using (var streamReader = new StreamReader(
        Assembly.GetExecutingAssembly().GetManifestResourceStream($"Monolith.VM.Test.Programs.{name}")))
      {
        return streamReader.ReadToEnd();
      }
    }

    public static Program Load(string name)
    {
      var sourceCode = LoadSourceCode(name);
      var compiler = new MonoLangCompiler();
      var program = compiler.Compile(sourceCode);

      return program;
    }
  }
}