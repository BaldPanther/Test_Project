using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TrafficLightColor_", menuName = "TrafficLightColor")]
public class TrafficLightColor : ScriptableObject
{
    [SerializeField] private Color _color;

    public Color Color => _color;

    public event Action ActivatedEvent;
    public event Action DeactivatedEvent;

    public void Activate() => ActivatedEvent?.Invoke();
    public void Deactivate() => DeactivatedEvent?.Invoke();
}
