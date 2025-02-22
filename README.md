## Commands Description

### Overview

The Command Package implements the core principles of the Command pattern, but it is not a full implementation in the classical sense. Rather, it is a practical adaptation of the pattern for Unity. It allows developers to separate execution logic from execution time and execution place.
You can also take a look at [DuckHunt](https://github.com/TarasLazoriv/DuckHunt). It was created as a demonstration of the capabilities of this package.

### Key Components

* **Commands:** Define *what* to do (logic).
    * Implement the `ICommand` or `ICommandVoid<T>` interface.
* **Executors:** Define *when* to execute a command.
    * Implement the `ICommandExecutor` interface.
* **Runners:** Define *where* to execute a command.
    * Implement the `ICommandRunner` interface.

### Advantages

* **Readability:**
    * Logic, execution time, and execution place are separated,
    * making code more understandable and maintainable.
* **Flexibility:**
    * You can easily change logic, execution time, or execution place independently of each other.
* **Extensibility:**
    * You can create custom executors and runners to implement different scenarios.
* **Testability:**
    * Easier to test individual components (commands, executors, runners).
* **Reusability:**
    * Commands can be easily reused in different parts of the code.

### Differences from MonoBehaviour

| Feature | MonoBehaviour | Command Package |
|---|---|---|
| Logic | Mixed with execution time and execution place | Separate |
| Execution time | Defined by lifecycle methods (Awake, Start, Update) | Defined by executors |
| Execution place | Defined by the GameObject context | Defined by runners |
| Readability | Can be less readable for complex logic | More readable due to separation of concerns |
| Maintainability | Harder to modify individual parts | Easier to modify logic, execution time, or execution place |
| Extensibility | Limited by lifecycle methods | Easy to create custom components |

### Use Cases

**1) Outside Unity Context:**

* **Basic Elements:** Commands, executors, and runners are not Unity dependent.
* **Instantiating:** You can create them anywhere and however you want, without using Unity-specific methods.
* **Use Cases:**
    * Basic data operations (read, write, sort, filter).
    * Processing algorithms (search, encryption, compression).
    * Asynchronous tasks (data loading, network interaction).

**2) DI with Zenject:**

* **Registering Commands, Executors, and Runners:**

```c#
Container
    .Bind<ITestCommand>()
    .To<MyTestCommand>() // Your implementation of ITestCommand
    .AsSingle();

Container
    .Bind<ICommandRunner>()
    .To<CommandRunner>()
    .AsTransient();

Container
    .Bind<TestExecutor>()
    .AsSingle()
    .NonLazy();
```

**3) Standard Unity Component System:**

* **Write MonoBehaviour components to implement executors and runners.**

```c#
public sealed class TestMonoExecutor : CommandMonoExecutor
{
    [SerializeField] private MonoCommand m_command = default; // Your command
    [SerializeField] private CommandMonoRunner m_runner = default; // Standard (included in the package) mono runner

    protected override ICommandVoid<Action> Runner => m_runner;
    protected override ICommand Command => m_command;
}

public sealed class TestCommand : MonoCommand
{
    public override void Execute()
    {
        /*
        *
        * Some logic
        *
        */
    }
}
```

**4) Mixed Approach:**

* **Creating custom elements:**
    * Implement your custom executors, runners, and commands.
* **Mixing approaches:**
    * Use Zenject to register parts of the system, and the Unity component system for other parts.

### Additional Features

* **ValueContainer:** A simple data storage container. It can be used in many places. For example, a mono container can be used to hold references to objects in the scene and provide access to them through context of your DI.
* **Code generator:** Accelerate the development process.
* **Many ready-to-go components:** That you can use right away.
* **Custom providers:** Define your own ways to find and create commands, executors, and runners.
* **Extend the package:** Create your own interfaces and implementations to extend the functionality of Command Package.

**Project Example:**
[DuckHunt](https://github.com/TarasLazoriv/DuckHunt) is a real-world project that uses the Command Package to implement the game logic. The project demonstrates how to use all of the features of the package, and it provides a good example of how to use the package in a real application.

### Conclusion


The Command Package is a powerful tool that can significantly improve the quality of Unity code. By understanding its capabilities and use cases, developers can enhance code readability, maintainability, flexibility, and reusability.

I hope this summary provides a clear understanding of the Command Package's purpose, components, advantages, use cases, additional features, and real-world applications. Please let me know if you have any further questions.
