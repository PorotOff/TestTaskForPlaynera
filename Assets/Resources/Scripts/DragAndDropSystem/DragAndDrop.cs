using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public DraggableObjectState draggableObjectState { private get; set; }

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
}