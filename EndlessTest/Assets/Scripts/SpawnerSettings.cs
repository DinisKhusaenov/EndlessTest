using System;
using TMPro;
using UnityEngine;

public class SpawnerSettings : MonoBehaviour
{
    public event Action<float> SpeedChanged;
    public event Action<float> DistanceChanged;
    public event Action<float> TimeChanged;

    [SerializeField] private TMP_InputField _speed;
    [SerializeField] private TMP_InputField _distance;
    [SerializeField] private TMP_InputField _time;

    private void OnEnable()
    {
        _speed.onValueChanged.AddListener(OnSpeedValueChanged);
        _distance.onValueChanged.AddListener(OnDistanceValueChanged);
        _time.onValueChanged.AddListener(OnTimeValueChanged);

        _speed.onValidateInput += ValidateInput;
        _distance.onValidateInput += ValidateInput;
        _time.onValidateInput += ValidateInput;
    }

    private void OnDisable()
    {
        _speed.onValueChanged.RemoveListener(OnSpeedValueChanged);
        _distance.onValueChanged.RemoveListener(OnDistanceValueChanged);
        _time.onValueChanged.RemoveListener(OnTimeValueChanged);

        _speed.onValidateInput -= ValidateInput;
        _distance.onValidateInput -= ValidateInput;
        _time.onValidateInput -= ValidateInput;
    }

    private void OnSpeedValueChanged(string value)
    {
        if (int.TryParse(value, out int intValue))
        {
            if (intValue <= 0)
            {
                _speed.text = "";
                value = "";
            }
        }
        else
        {
            _speed.text = "";
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
            if (intValue <= 0)
            {
                _distance.text = "";
                value = "";
            }
        }
        else
        {
            _distance.text = "";
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
            if (intValue <= 0)
            {
                _time.text = "";
                value = "";
            }
        }
        else
        {
            _time.text = "";
        }

        if (value != "")
        {
            TimeChanged?.Invoke(int.Parse(value));
        }
    }

    private char ValidateInput(string text, int charIndex, char addedChar)
    {
        if (!char.IsDigit(addedChar))
        {
            return '\0';
        }

        return addedChar;
    }
}
