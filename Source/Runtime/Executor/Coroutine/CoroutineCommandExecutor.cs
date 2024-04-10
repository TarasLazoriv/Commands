using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineCommandExecutor : DefaultExecutor<Func<IEnumerator>>
    {
        protected abstract ICommand<IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => Command.Execute;
    }

    public abstract class CoroutineCommandExecutor<T1> : TargetExecutor<T1, Func<IEnumerator>>
    {
        protected abstract ICommand<T1, IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => ExecuteCommand;

        protected virtual IEnumerator ExecuteCommand()
        {
            return Command.Execute(Target);
        }
    }

    public abstract class CoroutineCommandExecutor<T1, T2> : TargetExecutor<T1, T2, Func<IEnumerator>>
    {
        protected abstract ICommand<T1, T2, IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => ExecuteCommand;

        protected virtual IEnumerator ExecuteCommand()
        {
            return Command.Execute(Target1, Target2);
        }


    }

    public abstract class CoroutineCommandExecutor<T1, T2, T3> : TargetExecutor<T1, T2, T3, Func<IEnumerator>>
    {
        protected abstract ICommand<T1, T2, T3, IEnumerator> Command { get; }
        protected override Func<IEnumerator> Context => ExecuteCommand;

        protected virtual IEnumerator ExecuteCommand()
        {
            return Command.Execute(Target1, Target2, Target3);
        }

    }
}