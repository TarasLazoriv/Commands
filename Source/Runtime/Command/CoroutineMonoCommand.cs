using System.Collections;
using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class CoroutineMonoCommand : MonoBehaviour, ICommand<IEnumerator>
    {
        public abstract IEnumerator Execute();
    }
    public abstract class CoroutineMonoCommand<T> : MonoBehaviour, ICommand<T, IEnumerator>
    {
        public abstract IEnumerator Execute(T target);
    }
}