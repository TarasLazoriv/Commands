namespace LazerLabs.Commands
{
    public abstract class ObservableValueContainer<T> : CustomObservable<T>, IValueContainer<T>
    {
        private T m_value;

        protected ObservableValueContainer(T value = default)
        {
            m_value = value;
        }



        T IReadOnlyValueContainer<T>.Value => m_value;

        T IValueContainer<T>.Value
        {
            get => m_value;
            set
            {
                if (!m_value.Equals(value))
                {
                    m_value = value;
                    NotifyObservers(m_value);
                }

            }
        }
    }
}
