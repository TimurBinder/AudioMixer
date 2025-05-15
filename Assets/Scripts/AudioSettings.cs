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

    private bool _isMasterOn = true;
    private AudioMixerSnapshot OnSnapshot;
    private AudioMixerSnapshot OffSnapshot;

    private void Awake()
    {
        OnSnapshot = _mixer.FindSnapshot(On);
        OffSnapshot = _mixer.FindSnapshot(Off);
    }

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
        float transitionDuration = 0.5f;

        if (_isMasterOn)
        {
            OffSnapshot.TransitionTo(transitionDuration);
            _isMasterOn = false;
        }
        else
        {
            OnSnapshot.TransitionTo(transitionDuration);
            _isMasterOn = true;
        }
    }

    public void ChangeVolume(float value, string parameterName)
    {
        float maxValue = 1f;
        float minValue = 0.0001f;

        if (value > maxValue)
            value = maxValue;
        else if (value < minValue)
            value = minValue;

        OnSnapshot.audioMixer.SetFloat(parameterName, Mathf.Log10(value) * 20);
    }
}
