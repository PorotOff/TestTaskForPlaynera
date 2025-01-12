using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    private Camera mainCamera;

    private float scrollingSpeed;

    private Bounds targetBounds; // Границы, в пределах которых камера может перемещаться.
    private float cameraHalfWidth; // Половина ширины камеры для расчётов границ.

    private Vector3 targetPosition; // Позиция, к которой должна двигаться камера.

    public void Initialise(float scrollingSpeed, Transform targetMoveWithinObject)
    {
        mainCamera = Camera.main;

        this.scrollingSpeed = scrollingSpeed;

        // Получаем границы объекта, внутри которых камера должна двигаться.
        targetBounds = targetMoveWithinObject.GetComponent<Renderer>().bounds;
        
        // Рассчитываем половину высоты и ширины камеры в мировых координатах.
        float cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;

        // Начальная позиция камеры.
        targetPosition = transform.position;
    }

    private void Update()
    {
        // Ограничиваем движение камеры по оси X в пределах границ targetBounds.
        targetPosition.x = Mathf.Clamp(
            targetPosition.x,
            targetBounds.min.x + cameraHalfWidth,
            targetBounds.max.x - cameraHalfWidth
        );

        // Плавно перемещаем камеру к целевой позиции.
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * scrollingSpeed
        );
    }

    public void ScrollLeft()
    {
        // Смещаем целевую позицию камеры влево.
        targetPosition += Vector3.left * scrollingSpeed * Time.deltaTime;
    }

    public void ScrollRight()
    {
        // Смещаем целевую позицию камеры вправо.
        targetPosition += Vector3.right * scrollingSpeed * Time.deltaTime;
    }
}