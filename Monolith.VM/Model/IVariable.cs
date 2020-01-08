using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.VM.Model
{
  public interface IVariable 
  {
    string Name { get; }
    void SetValue(ProcessContext context, IExpression value);
  }
}
