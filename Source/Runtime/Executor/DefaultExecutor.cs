using System;

namespace LazerLabs.Commands
{
    public abstract class DefaultExecutor : BaseExecutor<ICommandVoid<Action>, Action>
    {
        protected abstract ICommand Command { get; }

        protected override Action Context => Command.Execute;
    }
}