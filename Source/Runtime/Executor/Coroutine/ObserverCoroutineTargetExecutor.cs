using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class ObserverCoroutineTargetExecutor<TTarget> : CoroutineTargetExecutor<TTarget>, IObserver<TTarget>
    {
        private IDisposable m_disposable = default;
        protected override TTarget Target => m_target;

        private TTarget m_target = default;

        public virtual void OnCompleted()
        {
            UnSubscribe();
        }

        public virtual void OnError(Exception error)
        {
            throw error;
        }

        public virtual void OnNext(TTarget target)
        {
            m_target = target;
            if (Target != null)
            {
                Execute();
            }
            else
            {
                throw new NullReferenceException($"{nameof(ObserverTargetExecutor<TTarget>)} Target is null");
            }
        }
        
        protected virtual void UnSubscribe()
        {
            m_disposable?.Dispose();
            m_disposable = null;
        }
    }
}