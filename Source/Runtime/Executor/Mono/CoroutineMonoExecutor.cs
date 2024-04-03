using System;
using System.Collections;

namespace LazerLabs.Commands
{
    public abstract class CoroutineMonoExecutor : BaseMonoExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>
    {

    }
}