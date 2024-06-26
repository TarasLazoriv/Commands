using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineCommandObserverExecutor : ObserverExecutor<Func<IEnumerator>>
    {
        protected abstract ICommand<IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => Command.Execute;
    }

    public abstract class CoroutineCommandObserverExecutor<TObserver> : ObserverExecutor<TObserver, Func<IEnumerator>>
    {
        protected abstract ICommand<IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => Command.Execute;
    }
}