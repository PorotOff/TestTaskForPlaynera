using UnityEngine;

public class OnDragState : DraggableObjectState
{
    protected Rigidbody2D objectRigidbody;
    protected Collider2D objectCollider;
    protected Transform objectTransform;

    public OnDragState(Rigidbody2D objectRigidbody, Collider2D objectCollider, Transform objectTransform)
    {
        this.objectRigidbody = objectRigidbody;
        this.objectCollider = objectCollider;
        this.objectTransform = objectTransform;

        // Устанавливаем ограничения на объект. FreezeRotation запрещает вращение,
        // а FreezePositionX фиксирует позицию объекта по оси X.
        objectRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        objectRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;

        // Переключаем коллайдер в режим триггера, чтобы объект мог взаимодействовать
        // с другими объектами, не сталкиваясь физически.
        objectCollider.isTrigger = true;
    }

    public override void OnEnter()
    {
        // Отключаем гравитацию и сбрасываем скорость объекта, чтобы он "замер" на месте.
        objectRigidbody.gravityScale = 0;
        objectRigidbody.linearVelocity = Vector3.zero;
    }

    public override void OnExit()
    {
        // Восстанавливаем действие гравитации, когда объект покидает состояние.
        objectRigidbody.gravityScale = 1;
    }

    public override void OnStay()
    {
        // Перемещаем объект к позиции мыши. Обратите внимание на использование
        // `Camera.main.ScreenToWorldPoint`, чтобы преобразовать экранные координаты
        // мыши в мировые координаты.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newObjectPosition = new Vector3(mousePosition.x, mousePosition.y, objectTransform.position.z);

        objectTransform.position = newObjectPosition;
    }
}