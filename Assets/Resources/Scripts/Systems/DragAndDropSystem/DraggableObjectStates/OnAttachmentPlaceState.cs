using UnityEngine;

public class OnAttachmentPlaceState : OnDragState
{
    private Transform targetPlace;

    public OnAttachmentPlaceState(Rigidbody2D objectRigidbody, Collider2D objectCollider, Transform objectTransform, Transform targetPlace)
        : base(objectRigidbody, objectCollider, objectTransform)
    {
        this.targetPlace = targetPlace;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        Attach();
    }

    public override void OnStay()
    {
        base.OnStay();
    }

    public void Attach()
    {
        objectTransform.position = targetPlace.position;
    }
}