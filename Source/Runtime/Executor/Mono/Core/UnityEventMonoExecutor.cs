using System;
using UnityEngine;
using UnityEngine.Events;

namespace LazerLabs.Commands
{
    public abstract class BaseUnityEventMonoExecutor<TContext> : DefaultMonoExecutor<TContext>
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

        ~BaseUnityEventMonoExecutor()
        {
            UnSubscribe();
        }

    }

    public abstract class BaseUnityEventMonoExecutor<TEvent, TContext> : DefaultMonoExecutor<TContext>
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

        ~BaseUnityEventMonoExecutor()
        {
            UnSubscribe();
        }
    }        


    public abstract class UnityEventMonoExecutor<TEvent> : BaseUnityEventMonoExecutor<TEvent, Action>
    {
        protected override Action Context => () => Command.Execute();

        protected abstract ICommand Command { get; }

    }

}