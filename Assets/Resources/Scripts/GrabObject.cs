using UnityEngine;
using UnityEngine.EventSystems;

public class GrabObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private DragAndDrop dragAndDropableObject;

    public void OnPointerDown(PointerEventData eventData)
    {
        DragAndDrop dragAndDrop = eventData.pointerEnter.GetComponent<DragAndDrop>();
        if (dragAndDrop != null)
        {
            dragAndDropableObject = dragAndDrop;
            dragAndDropableObject.OnPointerDown();

            Debug.Log("OnPointerDown called");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragAndDropableObject != null)
        {
            dragAndDropableObject.DragForCoursor();

            Debug.Log("OnDrag called");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragAndDropableObject != null)
        {
            dragAndDropableObject.OnPointerUp();

            Debug.Log("OnPointerUp called");
        }
    }
}