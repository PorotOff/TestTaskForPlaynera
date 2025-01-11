using UnityEngine;

public abstract class DraggableObjectState
{
    private Rigidbody2D objectRigidbody;
    private Collider2D objectCollider;

    public DraggableObjectState(Rigidbody2D objectRigidbody, Collider2D objectCollider)
    {
        this.objectRigidbody = objectRigidbody;
        this.objectCollider = objectCollider;
    }

    public virtual void OnEnter()
    {
        objectRigidbody.gravityScale = 0;
        objectRigidbody.linearVelocity = Vector3.zero;
        objectCollider.isTrigger = true;
    }

    public virtual void OnExit()
    {
        objectRigidbody.gravityScale = 1;
        objectCollider.isTrigger = false;
    }

    public virtual void OnStay()
    {
        
    }
}