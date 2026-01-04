using UnityEngine;

namespace LazerLabs.Commands
{
    public abstract class MonoValueContainer<T> : MonoBehaviour, IValueContainer<T>
    {
        [field: SerializeField] private T Value { get; set; }

        T IReadOnlyValueContainer<T>.Value => Value;

        T IValueContainer<T>.Value
        {
            get => Value;
            set => Value = value;
        }
    }
}