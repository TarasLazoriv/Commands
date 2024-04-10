using UnityEngine;
using UnityEngine.Events;

namespace LazerLabs.Commands
{
    public abstract class UnityEventMonoExecutor<TContext> : DefaultMonoExecutor<TContext>
    {
        [SerializeField] protected bool OnStartSubscribe = default;
        protected abstract UnityEvent Event { get; }

        protected override void Start()
        {
            base.Start();
            if (OnStartSubscribe)
            {
                Subscribe();
            }
        }

        protected virtual void OnNext()
        {
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

        ~UnityEventMonoExecutor()
        {
            UnSubscribe();
        }

    }

    public abstract class UnityEventMonoExecutor<TEvent, TContext> : DefaultMonoExecutor<TContext>
    {
        [SerializeField] protected bool OnStartSubscribe = default;
        protected abstract UnityEvent<TEvent> Event { get; }

        protected override void Start()
        {
            base.Start();
            if (OnStartSubscribe)
            {
                Subscribe();
            }
        }

        public virtual void OnNext(TEvent _)
        {
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

        ~UnityEventMonoExecutor()
        {
            UnSubscribe();
        }
    }
}