using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TurnButtonAnimator : MonoBehaviour
{
    public static readonly int On = Animator.StringToHash("On");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Toggle(bool isOn)
    {
        _animator.SetBool(On, isOn);
    }
}
