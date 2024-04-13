using System;

namespace LazerLabs.Commands
{
    public abstract class TargetExecutor<TTarget, TContext> : DefaultExecutor<TContext>
    {
        protected abstract TTarget Target { get; }

    }

    public abstract class TargetExecutor<T1, T2, TContext> : DefaultExecutor<TContext>
    {
        protected abstract T1 Target1 { get; }
        protected abstract T2 Target2 { get; }

    }

    public abstract class TargetExecutor<T1, T2, T3, TContext> : DefaultExecutor<TContext>
    {
        protected abstract T1 Target1 { get; }
        protected abstract T2 Target2 { get; }
        protected abstract T3 Target3 { get; }

    }
}