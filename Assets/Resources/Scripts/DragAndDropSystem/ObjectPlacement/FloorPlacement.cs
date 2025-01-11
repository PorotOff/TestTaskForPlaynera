using System;
using UnityEngine;

public class FloorPlacement : MonoBehaviour
{
    private DragAndDrop dragAndDrop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        dragAndDrop = other.GetComponent<DragAndDrop>();

        if (dragAndDrop == null) throw new Exception("Не назначен DragAndDrop объект");

        Rigidbody2D objectRigidbody = dragAndDrop.GetComponent<Rigidbody2D>();
        Collider2D objectCollider = dragAndDrop.GetComponent<Collider2D>();

        dragAndDrop.draggableObjectState = new OnGroundState(objectRigidbody, objectCollider);
        dragAndDrop.OnEnter();

        Debug.Log($"Сейчас состояние объекта должно быть OnGroundState: {dragAndDrop.draggableObjectState.GetType().Name}");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (dragAndDrop == null) throw new Exception("Не назначен DragAndDrop объект");

        dragAndDrop.OnEnter();
    }
}