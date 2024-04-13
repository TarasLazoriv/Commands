using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class DefaultMonoExecutor<TContext> : BaseMonoExecutor<ICommandVoid<TContext>, TContext>
    {

        [SerializeField] protected bool OnStartExecute = default;


        protected virtual void Start()
        {
            if (OnStartExecute)
            {
                Execute();
            }
        }
    }
}