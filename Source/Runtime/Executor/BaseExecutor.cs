namespace LazerLabs.Commands
{
    public abstract class BaseExecutor<T1, T2> : ICommand where T1 : ICommandVoid<T2>
    {
        private readonly T1 m_runner = default;

        protected BaseExecutor(T1 runner)
        {
            m_runner = runner;
        }

        protected abstract T2 Context { get; }


        public virtual void Execute()
        {
            m_runner.Execute(Context);
        }

    }
}