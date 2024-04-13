using System;
using System.Threading.Tasks;

namespace LazerLabs.Commands
{
    public abstract class AsyncCommandExecutor : DefaultExecutor<Func<Task>>
    {
        protected abstract IAsyncCommand Command { get; }
        protected override Func<Task> Context => Command.Execute;
    }
}