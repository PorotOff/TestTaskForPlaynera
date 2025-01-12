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
        dragAndDrop = dragAndDropGameObject.GetComponent<DragAndDrop>();

        if (dragAndDrop == null) throw new Exception("Не назначен DragAndDrop объект");

        objectRigidbody = dragAndDrop.GetComponent<Rigidbody2D>();
        objectCollider = dragAndDrop.GetComponent<Collider2D>();
        objectTransform = dragAndDrop.transform;

        SetState();
        dragAndDrop.OnEnter();
    }

    protected virtual void OnStay(GameObject dragAndDropGameObject)
    {
        if (!IsCurrentStateValid())
        {
            SetState();
        }
    }

    protected virtual void OnExit()
    {
        dragAndDrop.draggableObjectState = new OnDragState(objectRigidbody, objectCollider, objectTransform);
    }

    protected abstract void SetState();
    protected abstract bool IsCurrentStateValid();
}
