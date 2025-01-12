using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D), typeof(DragAndDrop))]
public class GrabObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isObjectTouching = false;

    private DragAndDrop dragAndDrop;
    private Rigidbody2D objectRigidbody;
    private Collider2D objectCollider;

    private void Awake()
    {
        // Получаем компоненты, чтобы управлять поведением объекта.
        dragAndDrop = GetComponent<DragAndDrop>();
        objectRigidbody = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<Collider2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Переводим объект в состояние перетаскивания.
        dragAndDrop.draggableObjectState = new OnDragState(objectRigidbody, objectCollider, transform);
        dragAndDrop.OnEnter();

        isObjectTouching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isObjectTouching = false;

        // Вызываем выход из текущего состояния, завершив перетаскивание.
        dragAndDrop.OnExit();
    }

    private void Update()
    {
        if (isObjectTouching)
        {
            // Вызываем метод для обновления текущего состояния.
            dragAndDrop.OnStay();
        }
    }
}