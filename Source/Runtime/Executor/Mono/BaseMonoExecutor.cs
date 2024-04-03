using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class BaseMonoExecutor<T1, T2> : MonoBehaviour, ICommand where T1 : ICommandVoid<T2>
    {
        protected abstract BaseExecutor<T1, T2> BaseExecutor { get; }


        public virtual void Execute()
        {
            BaseExecutor.Execute();
        }

    }
}