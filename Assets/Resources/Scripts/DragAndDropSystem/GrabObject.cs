using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D), typeof(DragAndDrop))]
public class GrabObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public static event Action<Transform> OnDraggableObjectIsTouched;
    public static event Action OnDraggableObjectIsUnTouched;
    public static event Action<Transform> OnDraggableObjectTouching;

    private DragAndDrop dragAndDrop;
    private Rigidbody2D objectRigidbody;
    private Collider2D objectCollider;

    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop>();
        objectRigidbody = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<Collider2D>();

        dragAndDrop.draggableObjectState = new OnGroundState(objectRigidbody, objectCollider);
        dragAndDrop.draggableObjectState.OnExit();

        dragAndDrop.Initialise(transform);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragAndDrop.draggableObjectState = new OnDragState(objectRigidbody, objectCollider);
        dragAndDrop.OnEnter();

        Debug.Log($"Произошёл клик, теперь состояние объекта {dragAndDrop.draggableObjectState.GetType().Name}");

        OnDraggableObjectIsTouched?.Invoke(transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragAndDrop.DragForCoursor();

        OnDraggableObjectTouching?.Invoke(transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragAndDrop.OnExit();

        OnDraggableObjectIsUnTouched?.Invoke();  
    }
}