using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public static readonly string On = nameof(On);
    public static readonly string Off = nameof(Off);

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSlider _masterSlider;
    [SerializeField] private AudioSlider _musicSlider;
    [SerializeField] private AudioSlider _buttonsSoundSlider;
    [SerializeField] private TurnButtonAnimator _turnButtonAnimator;

    private bool _isMasterOn = true;

    private void OnEnable()
    {
        _masterSlider.OnVolumeChanged += ChangeVolume;
        _musicSlider.OnVolumeChanged += ChangeVolume;
        _buttonsSoundSlider.OnVolumeChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        _masterSlider.OnVolumeChanged -= ChangeVolume;
        _musicSlider.OnVolumeChanged -= ChangeVolume;
        _buttonsSoundSlider.OnVolumeChanged -= ChangeVolume;
    }

    public void ToggleMusic()
    {
        if (_isMasterOn)
        {
            ChangeVolume(0, _masterSlider.AudioMixerGroupName);
            _isMasterOn = false;
        }
        else
        {
            ChangeVolume(_masterSlider.SliderValue, _masterSlider.AudioMixerGroupName);
            _isMasterOn = true;
        }

        _turnButtonAnimator.Toggle(_isMasterOn);
    }

    public void ChangeVolume(float value, string parameterName)
    {
        if (parameterName == _masterSlider.AudioMixerGroupName && _isMasterOn == false)
        {
            _isMasterOn = true;
            _turnButtonAnimator.Toggle(_isMasterOn);
        }

        float maxValue = 1f;
        float minValue = 0.0001f;
        float step = 20;

        if (value > maxValue)
            value = maxValue;
        else if (value < minValue)
            value = minValue;

        _mixer.SetFloat(parameterName, Mathf.Log10(value) * step);
    }
}
