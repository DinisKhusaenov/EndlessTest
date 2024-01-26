using System;
using TMPro;
using UnityEngine;

public class SpawnerSettings : MonoBehaviour
{
    public event Action<float> SpeedChanged;
    public event Action<float> DistanceChanged;
    public event Action<float> TimeChanged;

    private const string IncorrectValue = "¬ведите другое значение";
    private const float MinNumber = 0;

    [SerializeField] private TMP_InputField _speed;
    [SerializeField] private TMP_InputField _distance;
    [SerializeField] private TMP_InputField _time;

    private void OnEnable()
    {
        _speed.onValueChanged.AddListener(OnSpeedValueChanged);
        _distance.onValueChanged.AddListener(OnDistanceValueChanged);
        _time.onValueChanged.AddListener(OnTimeValueChanged);
    }

    private void OnDisable()
    {
        _speed.onValueChanged.RemoveListener(OnSpeedValueChanged);
        _distance.onValueChanged.RemoveListener(OnDistanceValueChanged);
        _time.onValueChanged.RemoveListener(OnTimeValueChanged);
    }

    private void OnSpeedValueChanged(string value)
    {
        if (int.TryParse(value, out int intValue))
        {
            if (intValue <= MinNumber)
            {
                _speed.text = "";
                value = "";
            }
        }
        else
        {
            _speed.text = "";
            Debug.Log(IncorrectValue);
            return;
        }

        if (value != "")
        {
            SpeedChanged?.Invoke(int.Parse(value));
        }
    }

    private void OnDistanceValueChanged(string value)
    {
        if (int.TryParse(value, out int intValue))
        {
            if (intValue <= MinNumber)
            {
                _distance.text = "";
                value = "";
            }
        }
        else
        {
            _distance.text = "";
            Debug.Log(IncorrectValue);
            return;
        }

        if (value != "")
        {
            DistanceChanged?.Invoke(int.Parse(value));
        }
    }

    private void OnTimeValueChanged(string value)
    {
        if (int.TryParse(value, out int intValue))
        {
            if (intValue <= MinNumber)
            {
                _time.text = "";
                value = "";
            }
        }
        else
        {
            _time.text = "";
            Debug.Log(IncorrectValue);
            return;
        }

        if (value != "")
        {
            TimeChanged?.Invoke(int.Parse(value));
        }
    }
}
