namespace LazerLabs.Commands
{
    public abstract class TargetMonoExecutor<TTarget, TContext> : DefaultMonoExecutor<TContext>
    {
        protected abstract TTarget Target { get; }

    }
}