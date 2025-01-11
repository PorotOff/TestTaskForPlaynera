using UnityEngine;

public class SheflAttachment : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();
        
        if (dragAndDrop != null)
        {
            Rigidbody2D objectRigidbody = dragAndDrop.GetComponent<Rigidbody2D>();
            Collider2D objectCollider = dragAndDrop.GetComponent<Collider2D>();
            Transform targetPlace = transform;
            Transform objectTransform = dragAndDrop.transform;

            dragAndDrop.draggableObjectState = new OnAttachmentPlaceState(objectRigidbody, objectCollider, targetPlace, objectTransform);
            dragAndDrop.OnEnter();
        }
    }
}