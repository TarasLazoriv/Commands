using System;
using System.Threading.Tasks;
using UnityEngine;

namespace LazerLabs.Commands
{
    public sealed class MonoButtonExecutor : ButtonCommandExecutor
    {
        [SerializeField] private CommandMonoRunner m_commandRunner = default;
        [SerializeField] private MonoCommand m_monoCommand = default;

        protected override ICommandVoid<Action> Runner => m_commandRunner;
        protected override ICommand Command => m_monoCommand;
    }
}