using System;

namespace LazerLabs.Commands
{
    public sealed class CommandRunner : ICommandVoid<Action>
    {

        public void Execute(Action command)
        {
            command?.Invoke();
        }
    }
}