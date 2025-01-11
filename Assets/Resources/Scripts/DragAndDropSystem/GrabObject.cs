using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D), typeof(DragAndDrop))]
public class GrabObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public static event Action OnDraggableObjectIsTouched;
    public static event Action OnDraggableObjectIsUnTouched;
    public static event Action OnDraggableObjectTouching;

    private DragAndDrop dragAndDrop;
    private Rigidbody2D objectRigidbody;
    private Collider2D objectCollider;

    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop>();
        objectRigidbody = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<Collider2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragAndDrop.draggableObjectState = new OnDragState(objectRigidbody, objectCollider, transform);
        dragAndDrop.OnEnter();

        OnDraggableObjectIsTouched?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragAndDrop.OnStay();

        OnDraggableObjectTouching?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragAndDrop.OnExit();

        OnDraggableObjectIsUnTouched?.Invoke();  
    }
}