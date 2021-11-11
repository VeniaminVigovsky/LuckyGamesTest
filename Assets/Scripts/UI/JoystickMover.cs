using UnityEngine;
using UnityEngine.EventSystems;
public class JoystickMover : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    private CustomOnScreenStick _joystick;

    public void OnDrag(PointerEventData eventData)
    {
        _joystick?.OnDrag(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {        
        _joystick.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystick.OnPointerUp(eventData);
    }
}
