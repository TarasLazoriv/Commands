using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class MonoInputKeyCodeExecutor : DefaultMonoExecutor
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