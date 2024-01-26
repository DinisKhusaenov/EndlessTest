using UnityEngine;

public class CubeFactory
{
    private Cube _prefab;

    public CubeFactory(Cube prefab)
    {
        _prefab = prefab;
    }

    public Cube Get(float speed, float destructionDistance, Vector3 spawnPosition)
    {
        var cube = Object.Instantiate(_prefab);
        cube.transform.position = spawnPosition;
        cube.Launch(speed, destructionDistance, spawnPosition);
        return cube;
    }
}
