using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    private Camera mainCamera;

    private float scrollingSpeed;

    private Bounds targetBounds;
    private float cameraHalfWidth;

    private Vector3 targetPosition;

    public void Initialise(float scrollingSpeed, Transform targetMoveWithinObject)
    {
        mainCamera = Camera.main;

        this.scrollingSpeed = scrollingSpeed;

        targetBounds = targetMoveWithinObject.GetComponent<Renderer>().bounds;
        
        float cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;

        targetPosition = transform.position;
    }

    private void Update()
    {
        targetPosition.x = Mathf.Clamp(
            targetPosition.x,
            targetBounds.min.x + cameraHalfWidth,
            targetBounds.max.x - cameraHalfWidth
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * scrollingSpeed
        );
    }

    public void ScrollLeft()
    {
        targetPosition += Vector3.left * scrollingSpeed * Time.deltaTime;
    }

    public void ScrollRight()
    {
        targetPosition += Vector3.right * scrollingSpeed * Time.deltaTime;
    }
}