using UnityEngine;

public class OnDragState : DraggableObjectState
{
    protected Rigidbody2D objectRigidbody;
    protected Collider2D objectCollider;
    protected Transform objectTransform;

    public OnDragState(Rigidbody2D objectRigidbody, Collider2D objectCollider, Transform objectTransform)
    {
        this.objectRigidbody = objectRigidbody;
        this.objectCollider = objectCollider;
        this.objectTransform = objectTransform;

        objectRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        objectRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;

        objectCollider.isTrigger = true;
    }

    public override void OnEnter()
    {
        objectRigidbody.gravityScale = 0;
        objectRigidbody.linearVelocity = Vector3.zero;
    }

    public override void OnExit()
    {
        objectRigidbody.gravityScale = 1;
    }

    public override void OnStay()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newObjectPosition = new Vector3(mousePosition.x, mousePosition.y, objectTransform.position.z);

        objectTransform.position = newObjectPosition;
    }
}