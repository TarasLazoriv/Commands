using System;
using UnityEngine;
using UnityEngine.Events;

namespace LazerLabs.Commands
{
    public abstract class BaseUnityEventTargetMonoExecutor<TTarget, TContext> : TargetMonoExecutor<TTarget, TContext>
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

        ~BaseUnityEventTargetMonoExecutor()
        {
            UnSubscribe();
        }

    }

    public abstract class UnityEventTargetMonoExecutor<TEvent, TContext> : BaseUnityEventMonoExecutor<TEvent, Action>
    {
        protected override Action Context => () => Command.Execute(Target);

        protected abstract ICommandVoid<TContext> Command { get; }
        protected abstract TContext Target { get; }

    }

    public abstract class UnityEventTargetMonoExecutor<TContext> : BaseUnityEventTargetMonoExecutor<TContext, Action>
    {
        protected override Action Context => () => Command.Execute(Target);

        protected abstract ICommandVoid<TContext> Command { get; }

    }
}