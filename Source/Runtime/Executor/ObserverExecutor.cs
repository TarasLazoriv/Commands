using System;

namespace LazerLabs.Commands
{
    public abstract class ObserverExecutor : ObserverExecutor<Unit> { }
    public abstract class ObserverExecutor<T> : DefaultExecutor, IObserver<T>
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

        public virtual void OnNext(T _)
        {
            Execute();
        }

        protected virtual void UnSubscribe()
        {
            m_disposable?.Dispose();
            m_disposable = null;
        }
    }
}