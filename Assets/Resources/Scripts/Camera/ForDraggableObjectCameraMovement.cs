using UnityEngine;

public class ForDraggableObjectCameraMovement : MonoBehaviour
{
    private void OnEnable()
    {
        GrabObject.OnDraggableObjectTouching += MoveForTargetObject;
    }
    private void OnDisable()
    {
        GrabObject.OnDraggableObjectTouching -= MoveForTargetObject;
    }

    private void MoveForTargetObject(Transform targetObject)
    {
        transform.position = new Vector3(targetObject.position.x, transform.position.y, transform.position.z);
    }
}