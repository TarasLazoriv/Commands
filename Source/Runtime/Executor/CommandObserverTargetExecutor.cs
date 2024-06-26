using System;

namespace LazerLabs.Commands
{
    public abstract class CommandObserverTargetExecutor<TTarget> : ObserverTargetExecutor<TTarget, Action>
    {
        protected abstract ICommandVoid<TTarget> Command { get; }
        protected override Action Context => ExecuteCommand;

        protected virtual void ExecuteCommand()
        {
            Command.Execute(Target);
        }
    }
}