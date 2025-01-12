using UnityEngine;

public class OnGroundState : OnDragState
{
    public OnGroundState(Rigidbody2D objectRigidbody, Collider2D objectCollider, Transform objectTransform) : base(objectRigidbody, objectCollider, objectTransform) { }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        
    }

    public override void OnStay()
    {
        base.OnStay();
    }
}