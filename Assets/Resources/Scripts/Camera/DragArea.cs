using UnityEngine;
using UnityEngine.EventSystems;

public class DragArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private DragAreaConfig dragAreaConfig;
    private CameraScrolling cameraScrolling;

    private bool isCoursorAbove = false;

    public void Initialize(DragAreaConfig dragAreaConfig, CameraScrolling cameraScrolling)
    {
        this.dragAreaConfig = dragAreaConfig;
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
            cameraScrolling.ScrollToward(dragAreaConfig.cameraScrollingXOffset);
        }
    }
}