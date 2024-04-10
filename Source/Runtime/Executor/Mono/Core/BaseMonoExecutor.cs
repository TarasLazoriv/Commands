using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class BaseMonoExecutor<T1, T2> : MonoBehaviour, ICommand where T1 : ICommandVoid<T2>
    {
        protected abstract T1 Runner { get; }
        protected abstract T2 Context { get; }


        public virtual void Execute()
        {
            Runner.Execute(Context);
        }

    }
}