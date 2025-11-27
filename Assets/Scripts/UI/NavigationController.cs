using UnityEngine;
using UnityEngine.EventSystems;

public class NavigationController : MonoBehaviour
{
    [SerializeField] private GameObject _start;

    private GameObject _lastSelected;

    private void Start()
    {
        SetObject(_start);
    }

    private void FixedUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == null) SetObject(_lastSelected); else _lastSelected = EventSystem.current.currentSelectedGameObject;
    }

    public void SetObject(GameObject obj) { EventSystem.current.SetSelectedGameObject(obj); _lastSelected = obj; }
}
