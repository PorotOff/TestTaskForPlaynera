using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DragAndDrop : MonoBehaviour
{
    private Rigidbody2D objectRigidbody;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody2D>();
    }

    public void DragForCoursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gameObject.transform.position = mousePosition;
    }

    public void OnPointerDown()
    {
        objectRigidbody.gravityScale = 0;
    }

    public void OnPointerUp()
    {
        objectRigidbody.gravityScale = 1;
    }
}