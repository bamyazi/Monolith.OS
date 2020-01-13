using System;

namespace Monolith.VM.Model
{
  public class IndexedVariable : IVariable, IExpression
  {
    private Index _index;

    private bool _isPointer;

    private IProcess _process;

    public IndexedVariable(string name, Index index, bool isPointer)
    {
      Name = name;
      _index = index;
      _isPointer = isPointer;
    }

    public void SetProcess(IProcess process)
    {
      _process = process;
    }

    #region IExpression Members

    private DataType _dataType;
    public DataType DataType => _dataType;

    public T GetValue<T>()
    {
      var expression = _process.Data.GetValue(Name);
      return expression.GetValue<T>();
    }

    public EqualityFlag Compare(IExpression expression)
    {
      throw new NotImplementedException();
    }

    public void Add(IExpression expression)
    {
    }

    public void Subtract(IExpression expression)
    {
    }

    public void Multiply(IExpression expression)
    {
    }

    public void Divide(IExpression expression)
    {
    }

    public IExpression Clone()
    {
      //throw new NotImplementedException();
      return new IndexedVariable(Name, _index, _isPointer);
    }

    #endregion

    #region IVariable Members

    public string Name { get; private set; }

    public void SetValue(IExpression value)
    {
      _dataType = value.DataType;
      _process.Data.SetValue(Name, value);
    }

    #endregion

  }
}