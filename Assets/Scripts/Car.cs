using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Car : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private SpriteRenderer _spriteRenderer;
    private Road _road;
    private Vector3 _finishPosition;

    public static event Action GameOverEvent;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(_road.CanMove)
            transform.Translate( _finishPosition * _speed * Time.deltaTime);
    }

    public void InitCar(Road road, Color color, Vector3 finishPosition)
    {
        _road = road;
        _spriteRenderer.color = color;
        _finishPosition = finishPosition;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Car _))
        {
            GameOverEvent?.Invoke();
        }
    }
}
