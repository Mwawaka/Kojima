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


# Classes
The primary object-oriented construct in C# is the class, which is a combination of data (fields) and behavior (methods). The fields and methods of a class are known as its members.

Access to members can be restricted through access modifiers, the two most common ones being:

- `public`: the member can be accessed by any code (no restrictions).
- `private`: the member can only be accessed by code in the same class.

You can think of a class as a template for creating instances of that class. To create an instance of a class (also known as an object), the new keyword is used:

```c#
class Car
{
}

// Create two car instances
var myCar = new Car();
var yourCar = new Car();
```

Fields have a type and can be defined anywhere in a class. Public fields are defined in `PascalCase` and private fields are defined in `camelCase` and prefixed with an underscore `_`:
```c#
class Car
{
    // Accessible by anyone
    public int Weight;

    // Only accessible by code in this class
    private string _color;
}
```
One can optionally assign an initial value to a field. If a field does not specify an initial value, it will be set to its type's default value. An instance's field values can be accessed and updated using dot-notation.

```c#
class Car
{
    // Will be set to specified value
    public int Weight = 2500;

    // Will be set to default value (0)
    public int Year;
}

var newCar = new Car();
newCar.Weight; // => 2500
newCar.Year;   // => 0

// Update value of the field
newCar.Year = 2018;
```
Private fields are usually updated as a side-effect of calling a method. Such methods usually don't return any value, in which case the return type should be void:

```c#
class CarImporter
{
    private int _carsImported;

    public void ImportCars(int numberOfCars)
    {
        // Update private field from public method
        _carsImported = _carsImported + numberOfCars;
    }
}
```

# Constants
The `const` modifier can be (and generally should be) applied to any field where its value is known at compile time and will not change during the lifetime of the program.

```c#
private const int num = 1729;
public const string title = "Grand" + " Master";
```

The `readonly` modifier can be (and generally should be) applied to any field that cannot be made const where its value will not change during the lifetime of the program and is either set by an inline initializer or during instantiation (by the constructor or a method called by the constructor).

```c#
private readonly int num;
private readonly System.Random rand = new System.Random();

public MyClass(int num)
{
    this.num = num;
}
```

## Defensive Copying
In security sensitive situations you should avoid allowing a class's public API to be circumvented by accepting and storing a method's mutable parameters or by exposing a mutable member of a class through a return value or as an `out` parameter.

## Readonly Collections
While the readonly modifier prevents the value or reference in a field from being overwritten, it offers no protection for the members of a reference type.

```c#
readonly List<int> ints = new List<int>();

void Foo()
{
    ints.Add(1);    // ok
    ints = new List<int>(); // fails to compile
}
```

To ensure that all members of a reference type are protected the fields can be made readonly and automatic properties can be defined without a set accessor.

The Base Class Library (BCL) provides some readonly versions of collections where there is a requirement to stop members of a collections being updated. These come in the form of wrappers:

`ReadOnlyDictionary<T>` exposes a `Dictionary<T>` as read-only.
`ReadOnlyCollection<T>` exposes a `List<T>` as read-only.