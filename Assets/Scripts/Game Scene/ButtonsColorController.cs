using UnityEngine;
using UnityEngine.UI;


// NO SE USA YA
public class ButtonsColorController : MonoBehaviour
{
    [Header("Botones")]
    public Button doButton;
    public Button faButton;
    public Button solButton;

    [Header("Backgrounds")]
    public Image doBackground;
    public Image faBackground;
    public Image solBackground;

    [Header("Colores")]
    public Color clickedColor = Color.green;

    void Awake()
    {
        doButton.onClick.AddListener(() => ChangeBackground(doBackground));
        faButton.onClick.AddListener(() => ChangeBackground(faBackground));
        solButton.onClick.AddListener(() => ChangeBackground(solBackground));
    }

    void ChangeBackground(Image background)
    {
        background.color = clickedColor;
    }
}
