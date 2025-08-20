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
# Floating Point Numbers
A floating-point number is a number with zero or more digits behind the decimal separator. Examples are -2.4, 0.1, 3.14, 16.984025 and 1024.0.

Different floating-point types can store different numbers of digits after the digit separator - this is referred to as its precision.

C# has three floating-point types:

- **float**: 4 bytes (~6-9 digits precision). Written as `2.45f`.
- **double**: 8 bytes (~15-17 digits precision). This is the most common type. Written as 2.45 or `2.45d`.
- **decimal**: 16 bytes (28-29 digits precision). Normally used when working with monetary data, as its precision reduces the chance of rounding errors. Written as` 2.45m`.

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

## Exception Filtering
`when` is the keyword in filtering exceptions. It is placed after the catch statement and can take a` Boolean` expression containing any values in scope at the time. If the expression evaluates to true then the block associated with that catch statement is executed otherwise the next catch statement, if any, is checked.

```c#
try
{
    // do stuff
}
catch (Exception ex) when (ex.Message != "")
{
    // output the message when it is not empty
}
catch (Exception ex)
{
    // show stack trace or something.
}
```

## User Defined Exceptions
A user-defined exception is any class defined in your code that is derived from System.Exception. It is subject to all the rules of class inheritance but in addition the compiler and language runtime treat such classes in a special way allowing their instances to be thrown and caught outside the normal control flow as discussed in the exceptions exercise.

User-defined exceptions are often used to carry extra information such as a message and other relevant data to be made available to the catching routines.

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
# Datetimes
A `DateTime` in C# is an `immutable` object that contains both date and time information. DateTime instances are manipulated by calling their methods. Once a DateTime has been constructed, its value can never change. Any methods that appear to modify a DateTime will actually return a new DateTime.

The textual representation of dates and times is dependent on the `culture`. Consider a DateTime with its date set to March 28 2019 and its time set to 14:30:59. 

Converting this DateTime to a string when using the en-US culture (American English) returns "3/28/19 2:30:59 PM". When using the fr-BE culture (Belgian French), the same code returns a different value: "28/03/19 14:30:59".

Understanding which DateTime methods are culture-dependent is important to know. In general, any DateTime method that deals with `strings` (either as input or output) will be dependent on the current culture.

# Dictionaries
A dictionary is a collection of elements where each element comprises a key and value such that if a key is passed to a method of the dictionary its associated value is returned. It has the same role as maps or associative arrays do in other languages.

A dictionary can be created as follows:

```c#
new Dictionary<int, string>();
// Empty dictionary

new Dictionary<int, string>
{
    [1] = "One",
    [2] = "Two"
};

new Dictionary<int, string>
{
    {1, "One"},
    {2, "Two"}
};
// 1 => "One", 2 => "Two"
```

Note that the key and value types are part of the definition of the dictionary.

Once constructed, entries can be added or removed from a dictionary using its built-in methods `Add` and `Remove`.

Retrieving or updating values in a dictionary is done by indexing into the dictionary using a key:

```c#
var numbers = new Dictionary<int, string>
{
   {1, "One"},
   {2, "Two"}
};

// Set the value of the element with key 2 to "Deux"
numbers[2] = "Deux";

// Get the value of the element with key 2
numbers[2];
// => "Deux"
```

You can test if a value exists in the dictionary with:

```c#
var dict = new Dictionary<string, string>{/*...*/};
dict.ContainsKey("some key that exists");
// => true
```

Enumerating over a dictionary will enumerate over its key/value pairs. Dictionaries also have properties that allow enumerating over its keys or values.

# Namespaces
Namespaces are a way to group related code and to avoid name clashes and are generally present in all but the most trivial code base.

The syntax is as follows:

```c#
namespace MyNameSpace
{
    public class MyClass {}

    public class OtherClass {}
}
```

Types enclosed in namespaces are referred to outside the scope of the namespace by prefixing the type name with the dot syntax. 

Alternatively, and more usually, you can place a `using` directive at the top of the file (or within a namespace) and type can be used without the prefix. Within the same namespace there is no need to qualify type names.

```c#
namespace MySpace
{
    public class MyClass {}

    public class Foo
    {
        public void Bar()
        {
            var baz = new MyClass();
        }
    }
}

public class Qux
{
    public void Box()
    {
        var nux = new MySpace.MyClass();
    }
}

namespace OtherSpace
{
    using MySpace;

    public class Tix
    {
        public void Jeg()
        {
            var lor = new MyClass();
        }
    }
}
```

You can alias a namespace with the syntax 
```c#
using MyAlias = MySpace; 
```
and then use the alias anywhere that the namespace could be used.

# Equality
Simple types (strings and primitives) are typically tested for equality with the `==` and `!=`.

Reference types (Instances of classes) are compared using the Equals() method inherited from `Object`.  By default, for classes `equals` means: Are these the same exact objects?(Like checking if two pointers point to the same thing).

If you know that all the instances of your class are created in one place, say characters in some game or simulation then reference equality is sufficient. 

However, it is likely that multiple instances of the same real-world entity will be created (from a database, by user input, via a web request).

 In this case `values that uniquely identify the entity` must be tested for equality. Therefore `Equals()` must be `overridden` and appropriate data members of your class are tested for equality.

An overridden `Equals()` method will contain equality tests on members of `simple types` using `==` and `reference types` with recursive calls to `Equals()`.

The Object class provides appropriate methods to compare two objects to detect if they are one and the same instance.

`Object.GetHashCode()`
The `Object.GetHashCode()` method returns a hash code in the form of a 32 bit integer. The hash code is used by dictionary and set classes such as `Dictionary<T>` and `HashSet<T>` to store and retrieve objects in a performant manner.

The relationship between hash code and equality is that if two objects are equal (Equal() returns true) then `GetHashCode()` for the two objects must return the same value. 

This does not apply in the reverse direction. It is not symmetrical. Just because two objects have the same hashcode they do not have to be equal. Picture a lookup function that first goes to a "bucket" based on the hash code and then picks out the particular item using the equality test.

The values used in the equality test must be stable while the hashed collection is in use. If you add an object to the collection with one set of values and then change those values the hash code will no longer point to the correct "bucket". 

 ## == vs is
In C#, you can check for `null` in two common ways:

```csharp
if (other == null) { ... }
```

or

```csharp
if (other is null) { ... }
```

They look almost the same, but there’s an **important difference**.

---

### 1. `== null`

When you write `other == null`, you are calling the **`==` operator**.

* If your class **overloads `==`**, then that custom operator is executed.
* This means you might not actually be checking for *true* `null`, but instead whatever logic was implemented in that operator.

Example:

```csharp
class Foo
{
    public static bool operator ==(Foo a, Foo b) => true; // silly example
    public static bool operator !=(Foo a, Foo b) => false;
}
```

Now:

```csharp
Foo f = null;
Console.WriteLine(f == null); // prints True (but only because of overloaded operator)
```

So it’s no longer guaranteed to be a pure reference `null` check.

---

### 2. `is null`

When you write `other is null`, this **always does a reference check**.

* It cannot be overloaded.
* It’s guaranteed to tell you if the variable truly holds `null`.

Example with the same `Foo`:

```csharp
Foo f = null;
Console.WriteLine(f is null); // always True, regardless of operator overload
```

---

✅ That’s why `is null` is considered safer and more explicit than `== null` in equality implementations — it avoids surprises if someone overloads `==`.


# Sets
A set is a collection of unique values. The default .NET implementation of a set is the `HashSet<T>` class, which is a collection that only contains unique values.

# Expression Bodied Members
Many types of struct and class members (fields being the primary exception) can use the expression-bodied member syntax. Defining a member with an expression often produces more concise and readable code than traditional blocks/statements.

Methods and read-only properties are amongst the members that can be defined with expression bodies.

```csharp
public int Times3(int input) => input * 3;

public int Interesting => 1729;
```

## Switch Expressions
A switch expression can match a value to one case in a set of patterns and return the associated value or take the associated action.

The association is denoted by the `=>` symbol. In addition, each pattern can have an optional case guard introduced with the `when` keyword. 

The case guard expression must evaluate to true for that "arm" of the switch to be selected. 

The cases (also known as switch arms) are evaluated in text order and the process is cut short and the associated value is returned as soon as a match is found.

```c#
double xx = 42d;

string interesting = xx switch
{
    0 => "I suppose zero is interesting",
    3.14 when DateTime.Now.Day == 14 && DateTime.Now.Month == 3 => "Mmm pie!",
    3.14 => "π",
    42 => "a bit of a cliché",
    1729 => "only if you are a pure mathematician",
    _ => "not interesting"
};

// => interesting == "a bit of a cliché"
```

## Conditionals Ternary
Ternary operators allow if-conditions to be defined in expressions rather than statement blocks. 

```c#
int a = 3, b = 4;
int max = a > b ? a : b;
// => 4
```

## Throw Expressions
throw expressions are an alternative to throw statements and in particular can add to the power of ternary and other compound expressions.

```c#
string trimmed = str == null ? throw new ArgumentException() : str.Trim();
```
# Attributes
A C# `Attribute` provides a way to decorate a declaration to associate metadata to: a class, a method, an enum, a field, a property or any other supported declarations.

You can apply an attribute by adding it on the line before the declaration using a `ClassAttribute` and a `FieldAttribute`:

```c#
[Class]
class MyClass
{
    [Field]
    int myField;
}
```

This declarative metadata only associates additional structured information to the code and does not modify its behavior, but that metadata is used by other part of the code to change how its target would behave or add, change or remove, restrict some its functionalities.

There are many predefined and reserved attributes, for example: `Flags, Obsolete, Conditional, and Experimental`. Each has a specific semantic meaning that can be looked up on the C# documentation. Note that the full name of an attribute like Flags takes the form <Name>Attribute (e.g. FlagsAttribute).

## Flag Enums
The C# enum type represents a fixed set of named constants (an enumeration).

Normally, one enum member can only refer to exactly one of those named constants. However, sometimes it is useful to refer to more than one constant. To do so, one can annotate the enum with the Flags attribute

A flags enum can be defined as follows (using binary integer notation 0b):

```c#
[Flags]
enum PhoneFeatures
{
    Call = 0b00000001,
    Text = 0b00000010
}
```
A `PhoneFeatures` instance which value is 0b00000011 has both its Call and Text flags set.

By default, the int type is used for enum member values. One can use a different integer type by specifying the type in the enum declaration:

```c#
[Flags]
enum PhoneFeatures : byte
{
    Call = 0b00000001,
    Text = 0b00000010
}
```

# Generic Types
A collection definition typically includes a place holder in angle brackets, often `T` by convention. 

Such a collection is referred to as a generic type. This allows the collection user to specify what type of items to store in the collection.

# Lists
Lists in C# are collections of primitive values or instances of structs or classes. They are implemented in the base class library as `List<T>` where `T` is the type of the item in the list. The API exposes a rich set of methods for creating and manipulating lists.

Items can be added to and removed from lists. They grow and shrink as necessary.

```c#
var listOfStrings = new List<string>();
```