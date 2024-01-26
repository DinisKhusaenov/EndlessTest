using System;
using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    private CubeFactory _cubeFactory;
    private float _spawnCooldown;
    private float _speed;
    private float _distance;

    private Coroutine _spawn;

    public void Initialize(CubeFactory cubeFactory)
    {
        _cubeFactory = cubeFactory;
    }

    public void StartWork()
    {
        StopWork();

        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            StopCoroutine(_spawn);
    }

    public void ChangeSpeed(float speed)
    {
        if (speed < 0)
            throw new ArgumentException(nameof(speed));

        _speed = speed;
    }

    public void ChangeDistance(float distance)
    {
        if (distance < 0)
            throw new ArgumentException(nameof(distance));

        _distance = distance;
    }

    public void ChangeTime(float time)
    {
        if (time < 0)
            throw new ArgumentException(nameof(time));

        _spawnCooldown = time;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _cubeFactory.Get(_speed, _distance, _spawnPosition.position);
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
