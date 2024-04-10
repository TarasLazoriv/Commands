using System;

namespace LazerLabs.Commands
{
    public abstract class CommandExecutor : DefaultExecutor<Action>
    {
        public abstract ICommand Command { get; }
        protected override Action Context => Command.Execute;
    }

    public abstract class CommandExecutor<T1> : TargetExecutor<T1, Action>
    {
        public abstract ICommandVoid<T1> Command { get; }
        protected override Action Context => ExecuteCommand;

        protected virtual void ExecuteCommand()
        {
            Command.Execute(Target);
        }
    }

    public abstract class CommandExecutor<T1, T2> : TargetExecutor<T1, T2, Action>
    {
        public abstract ICommandVoid<T1, T2> Command { get; }
        protected override Action Context => ExecuteCommand;

        protected virtual void ExecuteCommand()
        {
            Command.Execute(Target1, Target2);
        }


    }

    public abstract class CommandExecutor<T1, T2, T3> : TargetExecutor<T1, T2, T3, Action>
    {
        public abstract ICommandVoid<T1, T2, T3> Command { get; }
        protected override Action Context => ExecuteCommand;

        protected virtual void ExecuteCommand()
        {
            Command.Execute(Target1, Target2, Target3);
        }

    }
}
