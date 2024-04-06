using System;
using System.Collections;
using UnityEngine;

namespace LazerLabs.Commands
{
    public sealed class MonoCoroutineCommandRunner : MonoBehaviour, ICommandVoid<Func<IEnumerator>>, ICoroutineStoppable
    {
        private Coroutine m_coroutine = default;


        public void Execute(Func<IEnumerator> v1)
        {
            Execute();
            m_coroutine = StartCoroutine(v1?.Invoke());
        }

        public void Execute()
        {
            if (m_coroutine != null)
            {
                StopCoroutine(m_coroutine);
                m_coroutine = null;
            }
        }
    }
}