using System;

class Program
{
  static void Main()
  {
    string text = "abc";
    foreach (var foo in text) { }

    // no boxing
    using (var a = new DisposableStruct()) { }
    using (DisposableStruct.Instance) { }

    // yeah, no boxing too
    using (var b = new BadDisposableStruct()) { }
    using (BadDisposableStruct.Instance) { }
  }
}

struct DisposableStruct : IDisposable
{
  public void Dispose() { }
  public static readonly DisposableStruct Instance = new DisposableStruct();

  public int this[int index] {
    get { return index; }
  }
}

struct BadDisposableStruct : IDisposable
{
  void IDisposable.Dispose() { }
  public static readonly DisposableStruct Instance = new DisposableStruct();
}