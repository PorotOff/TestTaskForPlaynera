using UnityEngine;

public class OnGroundState : DraggableObjectState
{
    protected Rigidbody2D objectRigidbody;
    protected Collider2D objectCollider;

    public OnGroundState(Rigidbody2D objectRigidbody, Collider2D objectCollider)
    {
        this.objectRigidbody = objectRigidbody;
        this.objectCollider = objectCollider;
    }

    public override void OnEnter()
    {
        objectRigidbody.gravityScale = 0;
        objectRigidbody.linearVelocity = Vector3.zero;
        objectCollider.isTrigger = true;
    }

    public override void OnExit()
    {
        objectRigidbody.gravityScale = 1;
        objectCollider.isTrigger = false;
    }

    public override void OnStay()
    {
        
    }
}