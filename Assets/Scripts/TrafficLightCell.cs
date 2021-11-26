using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightCell : MonoBehaviour
{
    [SerializeField] private TrafficLightColor _trafficLightColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public TrafficLightColor TrafficLightColor => _trafficLightColor;
    
    private void OnEnable()
    {
        _trafficLightColor.ActivatedEvent += OnActivated;
        _trafficLightColor.DeactivatedEvent += OnDeactivated;
    }

    private void OnDisable()
    {
        _trafficLightColor.ActivatedEvent -= OnActivated;
        _trafficLightColor.DeactivatedEvent -= OnDeactivated;
    }
    
    private void OnActivated()
    {
        _spriteRenderer.color = _trafficLightColor.Color;
    }

    private void OnDeactivated()
    {
        var color = _trafficLightColor.Color;
        color.a = 0.15f;
        _spriteRenderer.color = color;
    }
}
