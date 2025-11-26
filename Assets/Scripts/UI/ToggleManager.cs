using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Animator _animator;

    public bool IsOn => _toggle.isOn;

    private void Start()
    {
        UpdateAnimator();
        _toggle.onValueChanged.AddListener(delegate { UpdateAnimator(); });
    }

    public void UpdateAnimator()
    {
        _animator.SetBool("isOn", _toggle.isOn);
    }
}
