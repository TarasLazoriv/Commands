using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineTargetExecutor<TTarget> : BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>
    {
        protected abstract ICommand<TTarget, IEnumerator> Command { get; }
        protected abstract TTarget Target { get; }

        protected override Func<IEnumerator> Context => GenerateContext;
        

        protected virtual IEnumerator GenerateContext()
        {
            if (Target != null)
            {
                return Command.Execute(Target);
            }
            else
            {
                throw new NullReferenceException($"{nameof(TargetExecutor<TTarget>)} Target is Null");
            }
        }
    }
}