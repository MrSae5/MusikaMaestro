using System.Collections;
using UnityEngine;

public class MainMenuNav : MonoBehaviour
{
    [SerializeField] private Transform _panels;
    [SerializeField] private GameObject _levelsPanel;

    private Vector3 _panelsPosition;

    private const float _SPEED = 16;
    private void Update()
    {
        PointerNav();
        _panels.localPosition = Vector3.Lerp(_panels.localPosition, _panelsPosition, Time.deltaTime * _SPEED);
    }

    private void PointerNav()
    {

    }

    public void MoveUp() { Move(new Vector2(0, 1080)); }
    public void MoveDown() { Move(new Vector2(0, -1080)); }
    public void MoveLeft() { Move(new Vector2(-1920, 0)); }
    public void MoveRight() { Move(new Vector2(1920, 0)); }

    public void SetLevelsPanel(bool enable) { _levelsPanel.SetActive(enable); }

    private bool _isMoving;
    private void Move(Vector2 direction)
    {
        if (_isMoving) return;

        StartCoroutine(MovementTimer_EVENT());
        _panelsPosition -= new Vector3(direction.x, direction.y, 0);
    }

    private IEnumerator MovementTimer_EVENT()
    {
        _isMoving = true;

        yield return new WaitForSeconds(0.4f);

        _isMoving = false;
    }
}
