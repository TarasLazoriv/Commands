using System;

namespace LazerLabs.Commands
{
    public abstract class ButtonCommandExecutor : BaseButtonExecutor<Action>
    {
        protected abstract ICommand Command { get; }
        protected override Action Context => Command.Execute;
    }
}