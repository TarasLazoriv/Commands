using System;

namespace LazerLabs.Commands
{
    public abstract class ObservableExecutor : DefaultExecutor, IObserver<Unit>
    {
        private IDisposable m_disposable = default;
        protected ObservableExecutor(ICommand command, ICommandVoid<Action> runner) : base(command, runner) { }

        public virtual void OnCompleted()
        {
            UnSubscribe();
        }

        public virtual void OnError(Exception error)
        {
            throw error;
        }

        public virtual void OnNext(Unit _)
        {
            Execute();
        }

        protected virtual void Subscribe(IObservable<Unit> v)
        {
            v.Subscribe(this);
        }
        protected virtual void UnSubscribe()
        {
            m_disposable?.Dispose();
            m_disposable = null;
        }
    }
}