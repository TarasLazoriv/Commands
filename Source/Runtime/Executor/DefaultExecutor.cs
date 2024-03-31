using System;

namespace LazerLabs.Commands
{
    public abstract class DefaultExecutor : BaseExecutor<ICommandVoid<Action>, Action>
    {
        private readonly ICommand m_command = default;

        protected override Action Context => m_command.Execute;

        protected DefaultExecutor(ICommand command, ICommandVoid<Action> runner) : base(runner)
        {
            m_command = command;
        }
    }
}