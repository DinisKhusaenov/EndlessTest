using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Cube _prefab;
    [SerializeField] private SpawnerSettings _spawnerSettings;

    private CubeFactory _cubeFactory;
    private SpawnerMediator _mediator;

    private void Awake()
    {
        _cubeFactory = new CubeFactory(_prefab);
        _mediator = new SpawnerMediator(_spawnerSettings, _cubeSpawner);

        _cubeSpawner.Initialize(_cubeFactory);
        _cubeSpawner.StartWork();
    }
}
