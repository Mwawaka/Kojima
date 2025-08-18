### Type Safety
Refers to a `feature` in programming languages and its type system that ensures operations on data `are consistent with the data's defined type`. This helps prevent type errors. i.e you cannot perform arithmetic operations on type string

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
The `const` modifier can be (and generally should be) applied to any field where its **value is known at compile time** and will not change during the lifetime of the program.

```c#
private const int _num = 1729;
public const string Title = "Grand" + " Master";
```

The `readonly` modifier can be (and generally should be) applied to any field that **cannot be made const where its value will not change during the lifetime of the program** and is either set by an inline initializer or during instantiation (by the constructor or a method called by the constructor).

```c#
private readonly int _num;
private readonly System.Random rand = new System.Random();

public MyClass(int _num)
{
    this._num = _num;
}
```

## Defensive Copying
It is a programming practice used to protect a class's internal state by preventing unintended modifications to mutable objects.
1. **Avoid storing mutable parameters directly**: When a method accepts mutable objects (e.g., lists, arrays, or other objects that can be changed) as parameters, don't store them directly in the class. Instead, create a copy of the object (a "defensive copy") to ensure the class's internal state can't be altered by external code modifying the original object.

2. **Avoid exposing mutable members**: When returning an object or passing it as an `out` parameter, don't expose mutable internal fields directly. Return a copy of the mutable object instead, so external code can't modify the class's internal state.

**Why this matters**: If a class stores or exposes mutable objects without copying, external code could modify those objects, bypassing the class's public API (e.g., getters/setters) and potentially breaking encapsulation or introducing security vulnerabilities.
```java
public class SecureClass {
    private List<String> data;

    // Constructor with defensive copying
    public SecureClass(List<String> input) {
        this.data = new ArrayList<>(input); // Copy to prevent external modification
    }

    // Getter with defensive copying
    public List<String> getData() {
        return new ArrayList<>(data); // Return a copy to prevent external modification
    }
}
```


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

# Inheritance
In C#, a class hierarchy can be defined using inheritance, which allows a derived class `(Car)` to inherit the behavior and data of its parent class `(Vehicle)`. If no parent is specified, the class inherits from the object class.

Parent classes can provide functionality to derived classes in three ways:

- Define a regular method.
- Define a `virtual` method, which is like a regular method but one that derived classes can change.
- Define an abstract method, which is a method without an implementation that derived classes must implement. A class with `abstract` methods must be marked as abstract too. Abstract classes cannot be instantiated.

The `protected` access modifier allows a parent class member to be accessed in a derived class, but blocks access from other classes.

Derived classes can access parent class members through the base keyword.

```c#
// Inherits from the 'object' class
abstract class Vehicle
{
    // Can be overridden
    public virtual void Drive()
    {
    }

    // Must be overridden
    protected abstract int Speed();
}

class Car : Vehicle
{
    public override void Drive()
    {
        // Override virtual method

        // Call parent implementation
        base.Drive();
    }

    protected override int Speed()
    {
        // Implement abstract method
    }
}
```
The constructor of a derived class will automatically call its parent's constructor before executing its own constructor's logic. Arguments can be passed to a parent class' constructor using the `base` keyword:

```c#
abstract class Vehicle
{
    protected Vehicle(int wheels)
    {
        Console.WriteLine("Called first");
    }
}

class Car : Vehicle
{
    public Car() : base(4)
    {
        Console.WriteLine("Called second");
    }
}
```

Where more than one class is derived from a base class the two (or more) classes will often implement different versions of a base class method. This is a very important principle called `polymorphism`. For instance in a variation on the above example we show how code using Vehicle can change its behavior depending on what type of vehicle has been instantiated.

```c#
abstract class Vehicle
{
   public abstract string GetDescription();
}

class Car : Vehicle
{
   public Car()
   {
   }

   public override string GetDescription()
   {
      return "Runabout";
   }
}

class Rig : Vehicle
{
   public Rig()
   {
   }

   public override string GetDescription()
   {
      return "Big Rig";
   }
}

Vehicle v1 = new Car();
Vehicle v2 = new Rig();

v1.GetDescription();
// => Runabout
v2.GetDescription();
// => Big private void OnRenderImage(RenderTexture src, RenderTexture dest) {
}
```

# Exceptions
Exceptions in C# provide a structured, uniform, and type-safe way of handling error conditions that occur during runtime. Proper handling of exceptions and error is important when trying to prevent application crashes.

In C#, all exceptions have `System.Exception` class as their base type. It contains important properties such as `Message`, which contains a human-readable description of the reason for the exception being thrown.

To signal that there should be an error in a certain part of the code, a new exception object needs to be created and then thrown, using the `throw` keyword:

```c#
using System;
static int Square(int number)
{
    if (number >= 46341)
    {
        throw new ArgumentException($"Argument {number} cannot be higher than 46340 as its' square doesn't fit into int type.");
    }
    return number * number;
}
```

When an exception gets thrown, the runtime has the task of finding a piece of code that is responsible for handling of that exception. If no appropriate handler is found, the runtime displays the unhandled exception message in addition to stopping the execution of the program.

To create a handler for an exception, C# uses the try-catch statement, which consists of a try block and one or more catch clauses.

The try block should contain and guard code that may result in the exception getting thrown. The catch clauses should contain code that handles the behavior of the program after the error has occurred. 

It is important to note that the order of exceptions matters after the try block, as when multiple exceptions are listed, the first matching `catch` clause is executed.

```c#
try
{
   if (number == 42)
   {
       throw new ArgumentException("The number cannot be equal to 42.", "number");
   }

   if (number < 0)
   {
      throw new ArgumentOutOfRangeException("number", "The number cannot be negative.");
   }

    // Process number ...
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine($"Number is out of range: {e.Message}.");
}
catch (ArgumentException)
{
    Console.WriteLine("Invalid number.");
}
```
# Interfaces
An interface is a type containing members defining a group of related functionality. It distances the uses of a class from the implementation allowing multiple different implementations or support for some generic behavior such as formatting, comparison or conversion.

The syntax of an interface is similar to that of a class or struct except that methods and properties `appear as the signature only` and no body is provided.

```c#
public interface ILanguage
{
    string LanguageName { get; set; }
    string Speak();
}

public class ItalianTaveller : ILanguage, ICloneable
{
    public string LanguageName { get; set; } =  "Italiano";

    public string Speak()
    {
        return "Ciao mondo";
    }

    public object Clone()
    {
        ItalianTaveller it = new ItalianTaveller();
        it.LanguageName = this.LanguageName;
        return it;
    }
}
```

All operations defined by the interface must be implemented.

Interfaces can contain instance methods and properties amongst other members

## Ordering
To allow an object to be compared to another object, it must implement the `IComparable<T> `interface. This interface has a single method that needs to be implemented: `int CompareTo(T other)`.

There are three possible return values for the CompareTo method:

- **Value smaller than zero**: the current object is smaller than the other object.
- **Value greater than zero**: the current object is greater than the other object.
- **Value is zero**: the current object is equal to the other object.

## Sort(Comparison<T>)
Sors the elements in the entire `List<T>` using the specified `Comparison<T>`. Calling the `Sort` method results in the use of the default comparer for the class implementing `IComparable<T>` interface.i.e., checkout `rcc`

# Enums
The C# enum type represents a fixed set of named constants (an enumeration). Its chief purpose is to provide a type-safe way of interacting with numeric constants, limiting the available values to a pre-defined set. A simple enum can be defined as follows:

```c#
enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
```

If not defined explicitly, enum members will automatically get assigned incrementing integer values, with the first value being zero. It is also possible to assign values explicitly:

```c#
enum Answer
{
    Maybe = 1,
    Yes = 3,
    No = 5
}
```