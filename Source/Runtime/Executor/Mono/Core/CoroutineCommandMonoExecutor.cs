using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineCommandMonoExecutor : DefaultMonoExecutor<Func<IEnumerator>>
    {
        protected abstract ICommand<IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => Command.Execute;
    }
    public abstract class CoroutineCommandMonoExecutor<T1> : TargetMonoExecutor<T1, Func<IEnumerator>>
    {
        protected abstract ICommand<T1, IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => ExecuteCommand;

        protected virtual IEnumerator ExecuteCommand()
        {
            return Command.Execute(Target);
        }
    }
}