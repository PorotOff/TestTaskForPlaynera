using UnityEngine;

public class OnAttachmentPlaceState : OnGroundState
{
    private Transform targetPlace;
    private Transform objectTransform;

    public OnAttachmentPlaceState(Rigidbody2D objectRigidbody, Collider2D objectCollider, Transform targetPlace, Transform objectTransform)
        : base(objectRigidbody, objectCollider)
    {
        this.targetPlace = targetPlace;
        this.objectTransform = objectTransform;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        objectTransform.position = targetPlace.position;
    }

    public override void OnStay()
    {
        base.OnStay();
    }
}