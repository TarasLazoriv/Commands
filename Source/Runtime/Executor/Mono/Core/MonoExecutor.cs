using System;
using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class MonoExecutor : CommandMonoExecutor
    {
        [SerializeField] private CommandMonoRunner m_commandRunner = default;
        [SerializeField] private MonoCommand m_monoCommand = default;


        protected override ICommandVoid<Action> Runner => m_commandRunner;
        protected override ICommand Command => m_monoCommand;

    }
}