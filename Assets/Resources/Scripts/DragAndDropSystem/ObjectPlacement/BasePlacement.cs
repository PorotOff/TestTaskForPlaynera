using System;
using UnityEngine;

public class BasePlacement : MonoBehaviour
{
    protected DragAndDrop dragAndDrop;

    protected Rigidbody2D objectRigidbody;
    protected Collider2D objectCollider;

    private void OnTriggerStay2D(Collider2D other)
    {
        OnStay(other.gameObject);
    }

    protected virtual void OnStay(GameObject dragAndDropGameObject)
    {
        if (dragAndDrop == null)
        {
            dragAndDrop = dragAndDropGameObject.GetComponent<DragAndDrop>();

            if (dragAndDrop == null) throw new Exception("Не назначен DragAndDrop объект");

            objectRigidbody = dragAndDrop.GetComponent<Rigidbody2D>();
            objectCollider = dragAndDrop.GetComponent<Collider2D>();

            dragAndDrop.draggableObjectState = new OnGroundState(objectRigidbody, objectCollider);
            dragAndDrop.OnEnter();

            Debug.Log("Назначен OnGroundState");
        }
    }
}