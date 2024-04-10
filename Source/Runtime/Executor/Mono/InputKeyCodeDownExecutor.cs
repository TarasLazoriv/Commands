using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class InputKeyCodeDownExecutor : DefaultMonoExecutor
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