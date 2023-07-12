using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick_Luna : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform knobTransform, joystickBackground;
    private Vector2 joystickCenter, movement = Vector2.zero;
    private void Awake()
    {
        joystickCenter = joystickBackground.position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateKnobPosition(eventData.position);
    }
    public void OnDrag(PointerEventData eventData)
    {
        UpdateKnobPosition(eventData.position);
        knobTransform.anchoredPosition = Vector2.ClampMagnitude(knobTransform.anchoredPosition, joystickBackground.sizeDelta.x / 2);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        knobTransform.anchoredPosition = Vector2.zero;
        movement = Vector2.zero;
    }
    private void UpdateKnobPosition(Vector2 touchPosition)
    {
        knobTransform.anchoredPosition = touchPosition - joystickCenter;
        movement = Vector2.ClampMagnitude(knobTransform.anchoredPosition / ((joystickBackground.sizeDelta.x - knobTransform.sizeDelta.x) / 2), 1f);
    }
    public Vector2 GetMovement()
    {
        return movement;
    }
}
