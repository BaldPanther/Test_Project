using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Car _carPrefab;

    private List<Car> _pool;

    private void Awake()
    {
        InitPool(20);
    }

    public Car GetCar(Vector3 startPosition, Quaternion rotation)
    {
        if (!TryGetObject(out Car car))
            car = CreateObject();

        car.transform.position = startPosition;
        car.transform.rotation = rotation;
        car.gameObject.SetActive(true);
        return car;
    }
    
    public bool TryGetObject(out Car obj)
    {
        foreach (var car in _pool)
        {
            if (!car.gameObject.activeInHierarchy)
            {
                obj = car;
                return true;
            }
        }

        obj = null;
        return false;
    }

    private void InitPool(int count)
    {
        _pool = new List<Car>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }
    
    private Car CreateObject()
    {
        Car createdObject = Instantiate(_carPrefab, transform);
        createdObject.gameObject.SetActive(false);
        _pool.Add(createdObject);
        return createdObject;
    }
}
