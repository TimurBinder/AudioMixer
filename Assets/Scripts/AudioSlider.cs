using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private Slider _slider;

    public string MixerName => _mixer.name;
    public float Value => _slider.value;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
}
