using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class ObservableCoroutineExecutor : CoroutineExecutor, IObserver<Unit>
    {
        private IDisposable m_disposable = default;
        protected ObservableCoroutineExecutor(ICommand<IEnumerator> command, ICommandVoid<Func<IEnumerator>> runner) : base(command, runner) { }

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