using System;
using UnityEngine;

namespace LazerLabs.Commands
{
    public sealed class CommandMonoRunner : MonoBehaviour, ICommandRunner
    {

        public void Execute(Action command)
        {
            command?.Invoke();
        }
    }
}