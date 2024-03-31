using System.Collections;
using UnityEngine;

namespace LazerLabs.Commands
{
    public interface ICoroutine
    {
        public Coroutine StartCoroutine(IEnumerator routine);

        public void StopCoroutine(Coroutine routine);
    }
}