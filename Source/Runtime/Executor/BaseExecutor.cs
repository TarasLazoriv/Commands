namespace LazerLabs.Commands
{
    public abstract class BaseExecutor<T1, T2> : ICommand where T1 : ICommandVoid<T2>
    {
        protected abstract T1 Runner { get; }
        protected abstract T2 Context { get; }


        public virtual void Execute()
        {
            Runner.Execute(Context);
        }

    }
}