using UnityEngine;

public class OnGroundState : DraggableObjectState
{
    public OnGroundState(Rigidbody2D objectRigidbody, Collider2D objectCollider) : base(objectRigidbody, objectCollider) { }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        
    }

    public override void OnStay()
    {
        
    }
}