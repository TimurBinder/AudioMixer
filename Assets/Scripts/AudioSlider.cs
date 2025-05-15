using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private Slider _slider;

    public event Action<float, string> OnVolumeChanged;

    public string AudioMixerGroupName => _audioMixerGroup.name;
    public float SliderValue => _slider.value;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeVolume()
    { 
        OnVolumeChanged?.Invoke(_slider.value, _audioMixerGroup.name);
    }
}
