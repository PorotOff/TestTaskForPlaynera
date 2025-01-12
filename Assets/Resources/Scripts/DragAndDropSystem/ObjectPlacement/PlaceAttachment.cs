using UnityEngine;

public class PlaceAttachment : BasePlacement
{
    protected Transform targetPlace;

    private void Awake()
    {
        targetPlace = transform;
    }

    protected override void OnEnter(GameObject dragAndDropGameObject)
    {
        base.OnEnter(dragAndDropGameObject);

        OnAttachmentPlaceState onAttachmentPlaceState = (OnAttachmentPlaceState)dragAndDrop.draggableObjectState;
        onAttachmentPlaceState.Attach();
    }

    protected override void SetState()
    {
        dragAndDrop.draggableObjectState = new OnAttachmentPlaceState(objectRigidbody, objectCollider, objectTransform, targetPlace);
    }

    protected override bool IsCurrentStateValid()
    {
        return dragAndDrop.draggableObjectState.GetType() == typeof(OnGroundState);
    }
}