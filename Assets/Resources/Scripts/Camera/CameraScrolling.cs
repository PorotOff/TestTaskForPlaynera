using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    private Camera mainCamera;

    private float speed;
    private float cameraHalfWidth;
    private float cameraHalfHeight;
    
    private Bounds targetMoveWithinObjectBounds;

    public void Initialize(float speed, Transform targetMoveWithinObject)
    {
        this.speed = speed;
        
        mainCamera = Camera.main;
        
        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;      
        
        targetMoveWithinObjectBounds = targetMoveWithinObject.GetComponent<Renderer>().bounds;
    }

    public void ScrollToLeft()
    {
        float newX = targetMoveWithinObjectBounds.min.x + cameraHalfWidth;
        
        newX = Mathf.Clamp(newX, targetMoveWithinObjectBounds.min.x + cameraHalfWidth, targetMoveWithinObjectBounds.max.x - cameraHalfWidth);
        
        Vector3 newPosition = new Vector3(newX, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newPosition, speed * Time.deltaTime);
    }

    public void ScrollToRight()
    {
        float newX = targetMoveWithinObjectBounds.max.x - cameraHalfWidth;
        
        newX = Mathf.Clamp(newX, targetMoveWithinObjectBounds.min.x + cameraHalfWidth, targetMoveWithinObjectBounds.max.x - cameraHalfWidth);
        
        Vector3 newPosition = new Vector3(newX, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newPosition, speed * Time.deltaTime);
    }

    // private void LateUpdate()
    // {
    //     Vector3 cameraPosition = mainCamera.transform.position;

    //     cameraPosition.x = Mathf.Clamp(cameraPosition.x, objectMinX + cameraHalfWidth, objectMaxX - cameraHalfWidth);

    //     mainCamera.transform.position = cameraPosition;
    // }
}
