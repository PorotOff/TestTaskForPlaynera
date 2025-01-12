public class GroundPlacement : BasePlacement
{
    protected override void SetState()
    {
        dragAndDrop.draggableObjectState = new OnGroundState(objectRigidbody, objectCollider, objectTransform);
    }

    protected override bool IsCurrentStateValid()
    {
        return dragAndDrop.draggableObjectState.GetType() == typeof(OnGroundState);
    }
}