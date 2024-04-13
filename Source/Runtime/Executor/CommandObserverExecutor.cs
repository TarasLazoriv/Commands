using System;

namespace LazerLabs.Commands
{

    public abstract class CommandObserverExecutor : ObserverExecutor<Action>
    {
        protected abstract ICommand Command { get; }
        protected override Action Context => Command.Execute;
    }

    public abstract class CommandObserverExecutor<TObserver> : ObserverExecutor<TObserver, Action>
    {
        protected abstract ICommand Command { get; }
        protected override Action Context => Command.Execute;
    }
}