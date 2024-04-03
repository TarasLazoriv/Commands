using System;

namespace LazerLabs.Commands
{
    public abstract class TargetExecutor<TTarget> : BaseExecutor<ICommandVoid<Action>, Action>
    {
        protected abstract ICommandVoid<TTarget> Command { get; }
        protected abstract TTarget Target { get; }

        protected override Action Context => GenerateContext;


        protected virtual void GenerateContext()
        {
            if (Target != null)
            {
                Command.Execute(Target);
            }
            else
            {
                throw new NullReferenceException($"{nameof(TargetExecutor<TTarget>)} Target is Null");
            }
        }
    }
}