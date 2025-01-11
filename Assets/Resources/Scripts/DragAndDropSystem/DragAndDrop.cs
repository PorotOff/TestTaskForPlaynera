using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public DraggableObjectState draggableObjectState { get; set; }

    private Transform currentTransform;

    public void Initialise(Transform currentTransform)
    {
        this.currentTransform = currentTransform;
    }

    public void OnEnter()
    {
        draggableObjectState.OnEnter();
    }

    public void OnExit()
    {
        draggableObjectState.OnExit();
    }

    public void OnStay()
    {
        draggableObjectState.OnStay();
    }

    public void DragForCoursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newObjectPosition = new Vector3(mousePosition.x, mousePosition.y, currentTransform.position.z);

        currentTransform.position = newObjectPosition;
    }
}