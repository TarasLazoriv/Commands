using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineCommand : ICommand<IEnumerator>
    {
        public abstract IEnumerator Execute();
    }
    public abstract class CoroutineCommand<T> : ICommand<T, IEnumerator>
    {
        public abstract IEnumerator Execute(T target);
    }
}