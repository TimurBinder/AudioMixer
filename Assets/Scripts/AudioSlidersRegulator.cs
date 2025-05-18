using System;
using UnityEngine;

public class AudioSlidersRegulator : MonoBehaviour
{
    public event Action<float, string> OnSliderChanged;

    public void ChangeVolume(AudioSlider slider)
    { 
        OnSliderChanged?.Invoke(slider.Value, slider.MixerName);
    }
}
