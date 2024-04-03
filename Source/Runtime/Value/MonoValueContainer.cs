using UnityEngine;

namespace LazerLabs.Commands
{
    //MonoValueContainer can only be ReadOnly, value is set via SerializeField.
    public abstract class MonoValueContainer<T> : MonoBehaviour, IReadOnlyValueContainer<T>
    {
        [field: SerializeField] public T Value { get; private set; }
    }
}