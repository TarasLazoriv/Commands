using System;
using UnityEngine;
using UnityEngine.Events;

namespace LazerLabs.Commands
{
    public abstract class UnityEventMonoExecutor : DefaultMonoExecutor
    {
        [SerializeField] protected bool OnStartSubscribe = default;
        protected abstract UnityEvent Event { get; }

        protected virtual void Start()
        {
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

    public abstract class UnityEventMonoExecutor<TEvent> : DefaultMonoExecutor
    {
        [SerializeField] protected bool OnStartSubscribe = default;
        protected abstract UnityEvent<TEvent> Event { get; }

        protected void Start()
        {
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