using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class MonoCommand : MonoBehaviour, ICommand
    {
        public abstract void Execute();
    }

    public abstract class MonoCommand<T> : MonoBehaviour, ICommandVoid<T>
    {
        public abstract void Execute(T target);
    }
}