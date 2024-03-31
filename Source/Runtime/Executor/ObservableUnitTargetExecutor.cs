using System;

namespace LazerLabs.Commands
{
    public abstract class ObservableUnitTargetExecutor<TTarget> : TargetExecutor<TTarget>, IObserver<Unit>
    {
        private IDisposable m_disposable = default;

        protected ObservableUnitTargetExecutor(ICommandVoid<TTarget> command, ICommandVoid<Action> runner) : base(command, runner) { }

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
                throw new NullReferenceException($"{nameof(ObservableExecutor)} Target is null");
            }
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