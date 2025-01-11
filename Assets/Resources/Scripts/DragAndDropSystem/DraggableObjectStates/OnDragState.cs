using UnityEngine;

public class OnDragState : OnGroundState
{
    protected Transform currentTransform;

    public OnDragState(Rigidbody2D objectRigidbody, Collider2D objectCollider, Transform currentTransform)
        : base(objectRigidbody, objectCollider)
    {
        this.currentTransform = currentTransform;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnStay()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newObjectPosition = new Vector3(mousePosition.x, mousePosition.y, currentTransform.position.z);

        currentTransform.position = newObjectPosition;
    }
}