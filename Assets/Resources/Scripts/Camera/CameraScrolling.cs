using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    private float speed;

    public void Initialize(float speed)
    {
        this.speed = speed;
    }

    public void ScrollToward(float xOffset)
    {
        Vector3 newPosition = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, speed);
    }
}