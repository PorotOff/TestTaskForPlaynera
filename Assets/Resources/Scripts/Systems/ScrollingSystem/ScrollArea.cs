using UnityEngine;

public class ScrollArea : MonoBehaviour
{
    private CameraScrolling cameraScrolling;
    private float screenWidth; // Ширина экрана в пикселях.

    private float areaWidth; // Ширина активной зоны скролла.

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
        // Получаем текущую позицию мыши на экране.
        Vector3 mousePosition = Input.mousePosition;

        // Проверяем наличие ввода (тап или нажатие мыши) перед проверкой зон.
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            // Проверяем, находится ли мышь в левой зоне экрана.
            if (IsMouseInLeftArea(mousePosition))
            {
                cameraScrolling.ScrollLeft();
            }

            // Проверяем, находится ли мышь в правой зоне экрана.
            if (IsMouseInRightArea(mousePosition))
            {
                cameraScrolling.ScrollRight();
            }
        }
    }

    private bool IsMouseInLeftArea(Vector3 mousePosition)
    {
        // Проверяем, находится ли мышь в левой активной зоне.
        return mousePosition.x <= areaWidth;
    }

    private bool IsMouseInRightArea(Vector3 mousePosition)
    {
        // Проверяем, находится ли мышь в правой активной зоне.
        return mousePosition.x >= screenWidth - areaWidth;
    }
}