using UnityEngine;
using UnityEngine.UI;

public class TextSizeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = TextController._Size;
    }

    public void UpdateSize()
    {
        TextController.UpdateTextSize(_slider.value);
    }
}
