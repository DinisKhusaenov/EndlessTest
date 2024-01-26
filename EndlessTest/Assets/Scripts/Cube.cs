using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _speed;
    private float _destructionDistance;
    private Vector3 _direction;
    private Vector3 _startPosition;

    private void Awake()
    {
        _direction = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);

        if (Vector3.Distance(_startPosition, transform.position) >= _destructionDistance)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(float speed, float destructionDistance, Vector3 startPosition)
    {
        _destructionDistance = destructionDistance;
        _speed = speed;
        _startPosition = startPosition;
    }
}
