using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineCommandObserverTargetExecutor<TTarget> : ObserverTargetExecutor<TTarget, Func<IEnumerator>>
    {
        protected abstract ICommand<TTarget, IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => ExecuteCommand;

        protected virtual IEnumerator ExecuteCommand()
        {
            return Command.Execute(Target);
        }
    }
}