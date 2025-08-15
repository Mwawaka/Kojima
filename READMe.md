### Type Safety
Refers to a property in programming languages and its type system that ensures operations on data are consistent with the data's defined type. This helps prevent type errors. i.e you cannot perform arithmetic operations on type string

An alternative to casting is type conversion using the is operator. This is typically applied to reference and nullable types.

```c#
object o = new Random();
if (o is Random rand)
{
    int ii = rand.Next();
    // now, do something random
}
```
If you need to detect the precise type of an object then is may be a little too permissive as it will return true for a class and any of the classes and interfaces from which it is derived directly or indirectly. typeof and Object.GetType() are the solution in this case.

```c#
object o = new List<int>();

o is ICollection<int> // true
o.GetType() == typeof(ICollection<int>) // false
o is List<int> // true
o.GetType() == typeof(List<int>) // true
// 
```