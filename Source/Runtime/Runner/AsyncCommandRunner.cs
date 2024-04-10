using System;
using System.Threading.Tasks;

namespace LazerLabs.Commands
{
    public interface IAsyncCommandRunner : ICommandVoid<Func<Task>> { }
    public sealed class AsyncCommandRunner : IAsyncCommandRunner
    {
        public async void Execute(Func<Task> v1)
        {
            await v1?.Invoke()!;
        }
    }
}