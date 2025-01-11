using UnityEngine;

public class OnDragState : DraggableObjectState
{
    public OnDragState(Rigidbody2D objectRigidbody, Collider2D objectCollider) : base(objectRigidbody, objectCollider) { }

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
        base.OnStay();
    }
}