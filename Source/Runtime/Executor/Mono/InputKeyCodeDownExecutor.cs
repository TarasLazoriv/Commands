using System;
using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class InputKeyCodeDownExecutor : DefaultMonoExecutor<Action>
    {
        [SerializeField] private KeyCode m_inputKeyCode = default;

        protected virtual void Update()
        {
            if (Input.GetKeyDown(m_inputKeyCode))
            {
                Execute();
            }
        }
    }
}