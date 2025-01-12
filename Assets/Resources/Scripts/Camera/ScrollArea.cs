using UnityEngine;

public class ScrollArea : MonoBehaviour
{
    private CameraScrolling cameraScrolling;
    private float screenWidth;

    private float areaWidth;

    public void Initialise(float areaWidth)
    {
        cameraScrolling = GetComponent<CameraScrolling>();
        screenWidth = Screen.width;

        this.areaWidth = areaWidth;
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            if (IsMouseInLeftArea(mousePosition))
            {
                cameraScrolling.ScrollLeft();
            }

            if (IsMouseInRightArea(mousePosition))
            {
                cameraScrolling.ScrollRight();
            }
        }
    }

    private bool IsMouseInLeftArea(Vector3 mousePosition)
    {
        Debug.Log("Мышка в левой зоне");

        return mousePosition.x <= areaWidth;
    }

    private bool IsMouseInRightArea(Vector3 mousePosition)
    {
        Debug.Log("Мышка в правой зоне");

        return mousePosition.x >= screenWidth - areaWidth;
    }
}
