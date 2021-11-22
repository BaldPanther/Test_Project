using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject _finishPoint;
    [SerializeField] private TrafficLightColor _trafficLightColor;
    [SerializeField] private CarSpawner _carSpawner;

    public bool CanMove { get; private set; }

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

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    private IEnumerator SpawnCar()
    {
        while (true)
        {
            float spawnTime = Random.Range(2f, 3f);
            var waitForSeconds = new WaitForSeconds(spawnTime);

            yield return waitForSeconds;
            yield return new WaitUntil(() => CanMove);
            Car car = _carSpawner.GetCar(_startPoint.transform.position, transform.rotation, transform);
            car.InitCar(this, _trafficLightColor, _finishPoint.transform.localPosition);
        }
    }

    private void OnActivated()
    {
        CanMove = true;
    }

    private void OnDeactivated()
    {
        CanMove = false;
    }
}
