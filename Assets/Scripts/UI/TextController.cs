using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextController : MonoBehaviour
{
    public static float _Size {  get; private set; }

    private TMP_Text _text;

    private float _minSize;
    private float _maxSize;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        _minSize = _text.fontSizeMin;
        _maxSize = _text.fontSizeMax;
        _text.enableAutoSizing = false;

        OnUpdateTextSize += UpdateSize;
    }

    private void Start()
    {
        UpdateSize();
    }

    public void UpdateSize()
    {
        _text.fontSize = Mathf.LerpUnclamped(_minSize, _maxSize, _Size);
    }

    private delegate void UpdateSizeEvent();
    private static UpdateSizeEvent OnUpdateTextSize;

    public static void UpdateTextSize(float size)
    {
        _Size = size;
        OnUpdateTextSize?.Invoke();
    }

    private void OnDestroy()
    {
        OnUpdateTextSize -= UpdateSize;
    }
}
