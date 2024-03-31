using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineExecutor : BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>
    {
        private readonly ICommand<IEnumerator> m_command = default;

        protected override Func<IEnumerator> Context => m_command.Execute;

        protected CoroutineExecutor(ICommand<IEnumerator> command, ICommandVoid<Func<IEnumerator>> runner) : base(runner)
        {
            m_command = command;
        }
    }
}