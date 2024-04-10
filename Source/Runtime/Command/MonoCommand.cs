using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class MonoCommand : ICommand
    {
        public abstract void Execute();
    }

    public abstract class MonoCommand<T> : ICommandVoid<T>
    {
        public abstract void Execute(T target);
    }
}