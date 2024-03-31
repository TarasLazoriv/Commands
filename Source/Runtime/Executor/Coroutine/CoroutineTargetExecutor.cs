using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineTargetExecutor<TTarget> : BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>
    {
        private readonly ICommand<TTarget, IEnumerator> m_command = default;
        protected abstract TTarget Target { get; }

        protected override Func<IEnumerator> Context => GenerateContext;

        protected CoroutineTargetExecutor(ICommand<TTarget, IEnumerator> command, ICommandVoid<Func<IEnumerator>> runner) : base(runner)
        {
            m_command = command;
        }

        protected virtual IEnumerator GenerateContext()
        {
            if (Target != null)
            {
                return m_command.Execute(Target);
            }
            else
            {
                throw new NullReferenceException($"{nameof(TargetExecutor<TTarget>)} Target is Null");
            }
        }
    }
}