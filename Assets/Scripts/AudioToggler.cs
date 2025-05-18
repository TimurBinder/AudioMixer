using UnityEngine;

public class AudioToggler : MonoBehaviour
{
    [SerializeField] private AudioTogglerAnimator _animator;
    [SerializeField] private AudioVolumeRegulator _regulator;
    [SerializeField] private AudioSlidersRegulator _slidersRegulator;
    [SerializeField] private AudioSlider _masterSlider;

    private bool _isMasterOn = true;

    private void OnEnable()
    {
        _slidersRegulator.OnSliderChanged += ToggleAnimator;
    }

    private void OnDisable()
    {
        _slidersRegulator.OnSliderChanged -= ToggleAnimator;
    }

    public void ToggleMusic()
    {
        if (_isMasterOn)
        {
            _regulator.ChangeVolume(_regulator.MinVolume, _masterSlider.MixerName);
            _isMasterOn = false;
        }
        else
        {
            _regulator.ChangeVolume(_masterSlider.Value, _masterSlider.MixerName);
            _isMasterOn = true;
        }

        _animator.Toggle(_isMasterOn);
    }

    private void ToggleAnimator(float value, string mixerName)
    {
        if (mixerName == _masterSlider.MixerName && value > _regulator.MinVolume)
        {
            if (_isMasterOn == false)
            {
                _isMasterOn = true;
                _animator.Toggle(_isMasterOn);
            }
        }
        else
        {
            if (_isMasterOn)
            {
                _isMasterOn = false;
                _animator.Toggle(_isMasterOn);
            }
        }
    }
}
