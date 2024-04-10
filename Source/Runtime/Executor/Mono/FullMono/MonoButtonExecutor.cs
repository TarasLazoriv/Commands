using System;
using UnityEngine;

namespace LazerLabs.Commands
{
    public sealed class MonoButtonExecutor : ButtonExecutor
    {
        [SerializeField] private CommandMonoRunner m_commandRunner = default;
        [SerializeField] private MonoCommand m_monoCommand = default;

        protected override ICommandVoid<Action> Runner => m_commandRunner;
        protected override ICommand Command => m_monoCommand;
    }


    public sealed class MonoExecutor : DefaultMonoExecutor
    {
        [SerializeField] private CommandMonoRunner m_commandRunner = default;
        [SerializeField] private MonoCommand m_monoCommand = default;

        protected override ICommandVoid<Action> Runner => m_commandRunner;
        protected override ICommand Command => m_monoCommand;
    }
}