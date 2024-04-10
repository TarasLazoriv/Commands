using System;

namespace LazerLabs.Commands
{
    public abstract class CommandMonoExecutor : DefaultMonoExecutor<Action>
    {
        protected abstract ICommand Command { get; }
        protected override Action Context => Command.Execute;
    }
    public abstract class CommandMonoExecutor<T1> : TargetMonoExecutor<T1, Action>
    {
        protected abstract ICommandVoid<T1> Command { get; }
        protected override Action Context => ExecuteCommand;

        protected virtual void ExecuteCommand()
        {
            Command.Execute(Target);
        }
    }
}