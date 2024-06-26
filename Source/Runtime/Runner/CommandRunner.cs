using System;

namespace LazerLabs.Commands
{
    public interface ICommandRunner : ICommandVoid<Action> { }
    public sealed class CommandRunner : ICommandRunner
    {

        public void Execute(Action command)
        {
            command?.Invoke();
        }
    }
}