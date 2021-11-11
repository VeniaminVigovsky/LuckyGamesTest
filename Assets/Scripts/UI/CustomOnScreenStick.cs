using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine;
using UnityEngine.Serialization;

public class CustomOnScreenStick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out _pointerDownPos);
        ((RectTransform)transform).anchoredPosition = _pointerDownPos;
        _tempPosition = _pointerDownPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out var position);
        var delta = position - (Vector2)_tempPosition;

        delta = Vector2.ClampMagnitude(delta, movementRange);
        ((RectTransform)transform).anchoredPosition = _tempPosition + (Vector3)delta;

        var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
        SendValueToControl(newPos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ((RectTransform)transform).anchoredPosition = _startPos;
        SendValueToControl(Vector2.zero);
    }

    private void Start()
    {
        _startPos = ((RectTransform)transform).anchoredPosition;
    }

    public float movementRange
    {
        get => _movementRange;
        set => _movementRange = value;
    }

    [FormerlySerializedAs("movementRange")]
    [SerializeField]
    private float _movementRange = 50;

    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string _controlPath;

    private Vector3 _startPos;
    private Vector2 _pointerDownPos;
    private Vector3 _tempPosition;

    protected override string controlPathInternal
    {
        get => _controlPath;
        set => _controlPath = value;
    }
}
