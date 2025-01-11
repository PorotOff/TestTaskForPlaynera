using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnGrabObjectEnableDragAreas : MonoBehaviour
{
    private List<DragArea> dragAreas = new List<DragArea>();

    private void Awake()
    {
        dragAreas = GetComponentsInChildren<DragArea>().ToList();

        DisableAll();
    }

    private void OnEnable()
    {
        GrabObject.OnDraggableObjectIsTouched += EnableAll;
        GrabObject.OnDraggableObjectIsUnTouched += DisableAll;
    }
    private void OnDisable()
    {
        GrabObject.OnDraggableObjectIsTouched -= EnableAll;
        GrabObject.OnDraggableObjectIsUnTouched -= DisableAll;
    }

    private void EnableAll()
    {
        foreach (var dragArea in dragAreas)
        {
            dragArea.gameObject.SetActive(true);
        }
    }

    private void DisableAll()
    {
        foreach (var dragArea in dragAreas)
        {
            dragArea.gameObject.SetActive(false);
        }
    }
}