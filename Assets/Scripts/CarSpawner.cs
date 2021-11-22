using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Car _carPrefab;

    public Car GetCar(Vector3 startPosition, Quaternion rotation,Transform transform) => Instantiate(_carPrefab, startPosition, rotation, transform);
}
