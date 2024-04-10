using System;
using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class InputKeyCodeUpExecutor : DefaultMonoExecutor<Action>
    {
        [SerializeField] private KeyCode m_inputKeyCode = default;

        protected virtual void Update()
        {
            if (Input.GetKeyUp(m_inputKeyCode))
            {
                Execute();
            }
        }
    }
}