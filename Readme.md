ReSharper Heap Allocations Viewer plugin
----------------------------------------

This plugins statically analyzes C# code to find all local object allocations happening.

* It can detect and visualize [all boxing cases](http://stackoverflow.com/questions/7995606/boxing-occurrence-in-c-sharp), including:
```c#
struct Boxing {
  void M(string a) {
    object obj = 42;                // implicit conversion Int32 ~> Object
    string path = a + '/' + obj;    // implicit conversion Char ~> Object
    int code = this.GetHashCode();  // non-overriden virtual method call on struct
    string caseA = E.A.ToString();  // the same, virtual call
    Action<string> action = this.M; // delegate from value type method
    Type type = this.GetType();     // GetType() call is always virtual
  }

  enum E { A, B, C }
}
```
* It can visualize some hidden allocations happening in C#, including:
```c#
class HiddenAllocations {
}
```

Roadmap:

* Review highlighting ranges (parameters, params methods)
* Make highlightings configurable, add ability to search occurances
* Roslyn and C# 6.0 changes support

[Changelog is here](Content/Changelog.md)

