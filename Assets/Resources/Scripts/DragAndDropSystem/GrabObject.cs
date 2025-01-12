using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D), typeof(DragAndDrop))]
public class GrabObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action OnDraggableObjectIsTouched;
    public static event Action OnDraggableObjectIsUnTouched;
    public static event Action OnDraggableObjectTouching;
    private bool isObjectTouching = false;

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

        isObjectTouching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isObjectTouching = false;

        dragAndDrop.OnExit();

        OnDraggableObjectIsUnTouched?.Invoke();
    }

    private void Update()
    {
        if (isObjectTouching)
        {
            dragAndDrop.OnStay();
            OnDraggableObjectTouching?.Invoke();
        }
    }
}