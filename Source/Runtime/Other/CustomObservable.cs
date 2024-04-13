using System;
using System.Collections.Generic;

namespace LazerLabs.Commands
{
    public abstract class CustomObservable<T> : IObservable<T>
    {
        private readonly List<IObserver<T>> m_observers = new List<IObserver<T>>();
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!m_observers.Contains(observer))
            {
                m_observers.Add(observer);
            }

            // Return IDisposable for unsubscribing
            return new Unsubscriber(m_observers, observer);
        }

        // Method that notifies observers of a change
        protected void NotifyObservers(T value)
        {
            foreach (IObserver<T> observer in m_observers)
            {
                observer.OnNext(value);
            }
        }

        private sealed class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<T>> m_observers = default;
            private readonly IObserver<T> m_observer = default;

            public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
            {
                m_observers = observers;
                m_observer = observer;
            }

            public void Dispose()
            {
                if (m_observers.Contains(m_observer))
                {
                    m_observers.Remove(m_observer);
                }
            }
        }
    }
}