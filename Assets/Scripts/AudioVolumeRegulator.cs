using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeRegulator : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSlidersRegulator _sliderRegulator;

    public float MaxVolume { get; private set; }
    public float MinVolume { get; private set; }

    private void Awake()
    {
        MaxVolume = 1f;
        MinVolume = 0.0001f;
    }

    private void OnEnable()
    {
        _sliderRegulator.OnSliderChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        _sliderRegulator.OnSliderChanged -= ChangeVolume;
    }

    public void ChangeVolume(float value, string parameterName)
    {
        float step = 20;

        if (value > MaxVolume)
            value = MaxVolume;
        else if (value < MinVolume)
            value = MinVolume;

        _mixer.SetFloat(parameterName, Mathf.Log10(value) * step);
    }
}
