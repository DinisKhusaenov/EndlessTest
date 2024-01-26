using System;

public class SpawnerMediator: IDisposable
{
    private SpawnerSettings _settings;
    private CubeSpawner _spawner;

    public SpawnerMediator(SpawnerSettings settings, CubeSpawner spawner)
    {
        _settings = settings;
        _spawner = spawner;

        _settings.SpeedChanged += OnSpeedChanged;
        _settings.DistanceChanged += OnDistanceChanged;
        _settings.TimeChanged += OnTimeChanged;
    }

    public void Dispose()
    {
        _settings.SpeedChanged -= OnSpeedChanged;
        _settings.DistanceChanged -= OnDistanceChanged;
        _settings.TimeChanged -= OnTimeChanged;
    }

    private void OnSpeedChanged(float speed)
    {
        _spawner.ChangeSpeed(speed);
    }

    private void OnDistanceChanged(float distance)
    {
        _spawner.ChangeDistance(distance);
    }

    private void OnTimeChanged(float time)
    {
        _spawner.ChangeTime(time);
    }
}
