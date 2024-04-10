using System;

namespace LazerLabs.Commands
{

    public abstract class CommandObserverExecutor : ObserverExecutor<Action>
    {
        public abstract ICommand Command { get; }
        protected override Action Context => Command.Execute;
    }

    public abstract class CommandObserverExecutor<TObserver> : ObserverExecutor<TObserver, Action>
    {
        public abstract ICommand Command { get; }
        protected override Action Context => Command.Execute;
    }
}