using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class ObserverCoroutineUnitTargetExecutor<TTarget> : CoroutineTargetExecutor<TTarget>, IObserver<Unit>
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

        public virtual void OnNext(Unit _)
        {
            if (Target != null)
            {
                Execute();
            }
            else
            {
                throw new NullReferenceException($"{nameof(ObserverExecutor)} Target is null");
            }
        }
        protected virtual void UnSubscribe()
        {
            m_disposable?.Dispose();
            m_disposable = null;
        }
    }
}