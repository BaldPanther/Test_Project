using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightCell : MonoBehaviour
{
    [SerializeField] private TrafficLightColor _trafficLightColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public TrafficLightColor TrafficLightColor => _trafficLightColor;
    private void Start()
    {
        _spriteRenderer.color = _trafficLightColor.Color;
    }
}
