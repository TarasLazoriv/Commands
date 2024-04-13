namespace LazerLabs.Commands
{
    public abstract class ValueContainer<T> : IValueContainer<T>
    {
        private T m_value;

        protected ValueContainer(T value = default)
        {
            m_value = value;
        }



        T IReadOnlyValueContainer<T>.Value => m_value;

        T IValueContainer<T>.Value
        {
            get => m_value;
            set => m_value = value;
        }
    }
}