The Commands Package is a flexible and extensible solution for organizing logic in Unity. It's inspired by the concept of promises and offers an elegant way to structure and execute code, promoting cleaner, more scalable, and easily maintainable projects.

Core Entities
Command
A Command represents a method or a set of logic that can be easily configured and combined. There are two types of commands: regular and target. Regular commands execute a given method, while target commands allow passing parameters to the executed method.

Runner
A Runner is a logic block responsible for executing commands. Currently, two types of runners are implemented: a regular runner and a coroutine-based runner. An asynchronous runner is planned for future implementation.

Executor
The Executor acts as a bridge between commands and runners. It is responsible for forming a delegate from a command and launching it on the appropriate runner at the right time. There are different types of executors, including a default executor, an IObservable-based executor, and a special executor for coroutines.

Usage
Here's a simple example of using the Commands Package:
```csharp
TestCommand command = new TestCommand();
CommandRunner runner = new CommandRunner();
TestExecutor executor = new TestExecutor(command, runner);

public class TestCommand : ICommandVoid<string>
{
    public void Execute(string v)
    {
        Debug.Log("Hello World");
    }
}

public class TestExecutor : DefaultExecutor
{
    public TestExecutor(ICommand command, ICommandVoid<Action> runner) : base(command, runner) { }
}

private void Update()
{
    if (Input.GetKeyUp(KeyCode.Space))
    {
        executor.Execute();
    }
}
```
Benefits
Reduced coupling with Unity, simplifying logic and making it more portable.
Flexible and easily scalable structure, allowing command combinations and complex logic creation.
Ability to use different types of runners, including coroutines and asynchronous operations (planned).
Future Development
Future plans include adding asynchronous types of commands, executors, and runners, as well as expanding the existing functionality of the package.

Potential Issues and Limitations:
-Possible performance issues with very large numbers of commands, as each command allocates some memory.
Requirements and Dependencies
The Commands Package has no external dependencies and can be used in any Unity project.

License
The Commands Package is licensed under the MIT License.
