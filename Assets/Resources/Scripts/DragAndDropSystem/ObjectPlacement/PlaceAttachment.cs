using UnityEngine;

public class PlaceAttachment : BasePlacement
{
    private Transform targetPlace;
    private Transform objectTransform;

    private void Awake()
    {
        targetPlace = transform;
    }

    protected override void OnStay(GameObject dragAndDropGameObject)
    {
        base.OnStay(dragAndDropGameObject);

        if (objectTransform == null)
        {
            objectTransform = dragAndDrop.transform;

            dragAndDrop.draggableObjectState = new OnAttachmentPlaceState(objectRigidbody, objectCollider, targetPlace, objectTransform);
            dragAndDrop.OnEnter();

            Debug.Log("Назначен OnAttachmentPlaceState");
        }
    }
}