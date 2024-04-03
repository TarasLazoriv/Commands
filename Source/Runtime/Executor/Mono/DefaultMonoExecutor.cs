using System;

namespace LazerLabs.Commands
{
    public abstract class DefaultMonoExecutor : BaseMonoExecutor<ICommandVoid<Action>, Action> { }
}