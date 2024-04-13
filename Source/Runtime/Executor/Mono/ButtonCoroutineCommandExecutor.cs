using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class ButtonCoroutineCommandExecutor : BaseButtonExecutor<Func<IEnumerator>>
    {
        protected abstract ICommand<IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => Command.Execute;
    }
}