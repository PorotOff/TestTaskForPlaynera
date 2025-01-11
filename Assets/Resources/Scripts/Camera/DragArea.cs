using UnityEngine;
using UnityEngine.EventSystems;

public class DragArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CameraScrolling cameraScrolling;

    private bool isCoursorAbove = false;

    public void Initialize(CameraScrolling cameraScrolling)
    {
        this.cameraScrolling = cameraScrolling;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isCoursorAbove = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCoursorAbove = false;
    }

    private void LateUpdate()
    {
        if (isCoursorAbove)
        {
            cameraScrolling.ScrollToward();
        }
    }
}