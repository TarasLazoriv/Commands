using System;
using System.Collections;
using UnityEngine;

namespace LazerLabs.Commands
{
    public sealed class MonoButtonCoroutineExecutor : ButtonCoroutineCommandExecutor
    {
        [SerializeField] private CoroutineCommandMonoRunner m_commandRunner = default;
        [SerializeField] private CoroutineMonoCommand m_monoCommand = default;

        protected override ICommandVoid<Func<IEnumerator>> Runner => m_commandRunner;
        protected override ICommand<IEnumerator> Command => m_monoCommand;
    }
}