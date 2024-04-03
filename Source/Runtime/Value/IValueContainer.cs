namespace LazerLabs.Commands
{
    public interface IValueContainer<T> : IReadOnlyValueContainer<T>
    {
        public new T Value { get; set; }
    }

    public interface IReadOnlyValueContainer<out T>
    {
        public T Value { get; }
    }
}