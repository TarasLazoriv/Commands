using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LazerLabs.Commands
{
    public abstract class ButtonExecutor : UnityEventMonoExecutor
    {
        [SerializeField] private Button m_button = default;
        protected override UnityEvent Event => m_button.onClick;

        protected virtual void Reset()
        {
            OnStartSubscribe = true;
        }
    }
}