using System;
using System.Collections;
using UnityEngine;

namespace LazerLabs.Commands
{
    public interface ICoroutineStoppable : ICommand { }
    public sealed class CoroutineCommandRunner : ICommandVoid<Func<IEnumerator>>, ICoroutineStoppable
    {
        private readonly ICoroutine m_coroutineLogic = default;
        private Coroutine m_coroutine = default;

        public CoroutineCommandRunner(ICoroutine coroutineLogic)
        {
            m_coroutineLogic = coroutineLogic;
        }

        public void Execute(Func<IEnumerator> v1)
        {
            Execute();
            m_coroutine = m_coroutineLogic.StartCoroutine(v1?.Invoke());
        }

        public void Execute()
        {
            if (m_coroutine != null)
            {
                m_coroutineLogic.StopCoroutine(m_coroutine);
                m_coroutine = null;
            }
        }
    }
}