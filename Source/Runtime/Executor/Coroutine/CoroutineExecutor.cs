using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineExecutor : BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>
    {
        protected abstract ICommand<IEnumerator> Command { get; }

        protected override Func<IEnumerator> Context => Command.Execute;

    }
}