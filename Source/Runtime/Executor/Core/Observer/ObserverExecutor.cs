using System;

namespace LazerLabs.Commands
{
    public abstract class ObserverExecutor<TContext> : ObserverExecutor<Unit, TContext> { }
    public abstract class ObserverExecutor<TObserver, TContext> : DefaultExecutor<TContext>, IObserver<TObserver>
    {
        private IDisposable m_disposable = default;

        public virtual void OnCompleted()
        {
            UnSubscribe();
        }

        public virtual void OnError(Exception error)
        {
            throw error;
        }

        public virtual void OnNext(TObserver _)
        {
            Execute();
        }

        protected virtual void UnSubscribe()
        {
            m_disposable?.Dispose();
            m_disposable = null;
        }

        ~ObserverExecutor()
        {
            UnSubscribe();
        }
    }
}