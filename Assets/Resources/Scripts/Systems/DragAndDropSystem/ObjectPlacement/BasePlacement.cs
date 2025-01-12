using System;
using UnityEngine;

public abstract class BasePlacement : MonoBehaviour
{
    protected DragAndDrop dragAndDrop;

    protected Rigidbody2D objectRigidbody;
    protected Collider2D objectCollider;
    protected Transform objectTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnEnter(other.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        OnStay(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnExit();
    }

    protected virtual void OnEnter(GameObject dragAndDropGameObject)
    {
        // Пытаемся получить компонент DragAndDrop с объекта. Если его нет, выбрасываем исключение,
        // чтобы быстро найти ошибку в работе с объектами.
        dragAndDrop = dragAndDropGameObject.GetComponent<DragAndDrop>();
        if (dragAndDrop == null) throw new Exception("Не назначен DragAndDrop объект");

        objectRigidbody = dragAndDrop.GetComponent<Rigidbody2D>();
        objectCollider = dragAndDrop.GetComponent<Collider2D>();
        objectTransform = dragAndDrop.transform;

        // Устанавливаем состояние объекта в зависимости от реализации производного класса.
        SetState();
        dragAndDrop.OnEnter();
    }

    protected virtual void OnStay(GameObject dragAndDropGameObject)
    {
        // Проверяем, корректно ли задано текущее состояние объекта, и при необходимости обновляем его.
        if (!IsCurrentStateValid())
        {
            SetState();
        }
    }

    protected virtual void OnExit()
    {
        // Возвращаем объект в состояние перетаскивания по умолчанию.
        dragAndDrop.draggableObjectState = new OnDragState(objectRigidbody, objectCollider, objectTransform);
    }

    // Методы, которые должны быть реализованы в наследниках для задания состояния объекта.
    protected abstract void SetState();
    protected abstract bool IsCurrentStateValid();
}