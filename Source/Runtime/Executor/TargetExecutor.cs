using System;

namespace LazerLabs.Commands
{
    public abstract class TargetExecutor<TTarget> : BaseExecutor<ICommandVoid<Action>, Action>
    {
        private readonly ICommandVoid<TTarget> m_command = default;
        protected abstract TTarget Target { get; }

        protected override Action Context => GenerateContext;

        protected TargetExecutor(ICommandVoid<TTarget> command, ICommandVoid<Action> runner) : base(runner)
        {
            m_command = command;
        }

        protected virtual void GenerateContext()
        {
            if (Target != null)
            {
                m_command.Execute(Target);
            }
            else
            {
                throw new NullReferenceException($"{nameof(TargetExecutor<TTarget>)} Target is Null");
            }
        }
    }
}