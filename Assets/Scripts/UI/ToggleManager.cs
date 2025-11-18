using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        UpdateAnimator();
    }

    public void UpdateAnimator()
    {
        _animator.SetBool("isOn", _toggle.isOn);
    }
}
