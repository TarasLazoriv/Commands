using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class DefaultMonoExecutor<TContext> : BaseMonoExecutor<ICommandVoid<TContext>, TContext>
    {

        [SerializeField] private bool m_onStartExecute = default;


        protected virtual void Start()
        {
            if (m_onStartExecute)
            {
                Execute();
            }
        }
    }
}