using System;

namespace LazerLabs.Commands
{
    public abstract class ObservableTargetExecutor<TTarget> : TargetExecutor<TTarget>, IObserver<TTarget>
    {
        private IDisposable m_disposable = default;
        protected override TTarget Target => m_target;

        private TTarget m_target = default;

        protected ObservableTargetExecutor(ICommandVoid<TTarget> command, ICommandVoid<Action> runner) : base(command, runner) { }

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
                throw new NullReferenceException($"{nameof(ObservableTargetExecutor<TTarget>)} Target is null");
            }
        }

        protected virtual void Subscribe(IObservable<TTarget> v)
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