using UnityEngine;
using UnityEngine.Events;

namespace LazerLabs.Commands
{
    public abstract class UnityEventTargetMonoExecutor<TTarget, TContext> : TargetMonoExecutor<TTarget, TContext>
    {
        [SerializeField] protected bool OnStartSubscribe = default;
        protected abstract UnityEvent<TTarget> Event { get; }
        protected override TTarget Target => m_target;

        private TTarget m_target = default;

        protected override void Start()
        {
            base.Start();
            if (OnStartSubscribe)
            {
                Subscribe();
            }
        }

        public virtual void OnNext(TTarget target)
        {
            m_target = target;
            Execute();
        }
        protected virtual void Subscribe()
        {
            Event.AddListener(OnNext);
        }

        protected virtual void UnSubscribe()
        {
            Event.RemoveListener(OnNext);
        }

        ~UnityEventTargetMonoExecutor()
        {
            UnSubscribe();
        }

    }
}