using UnityEngine;

public class PlaceAttachment : BasePlacement
{
    protected Transform targetPlace;

    private void Awake()
    {
        // Устанавливаем целевое место для объекта как текущее положение компонента.
        targetPlace = transform;
    }

    protected override void OnEnter(GameObject dragAndDropGameObject)
    {
        base.OnEnter(dragAndDropGameObject);

        // Приводим состояние объекта к OnAttachmentPlaceState и вызываем метод Attach для привязки.
        OnAttachmentPlaceState onAttachmentPlaceState = (OnAttachmentPlaceState)dragAndDrop.draggableObjectState;
        onAttachmentPlaceState.Attach();
    }

    protected override void SetState()
    {
        // Устанавливаем состояние объекта как OnAttachmentPlaceState с передачей целевой позиции.
        dragAndDrop.draggableObjectState = new OnAttachmentPlaceState(objectRigidbody, objectCollider, objectTransform, targetPlace);
    }

    protected override bool IsCurrentStateValid()
    {
        // Проверяем, находится ли объект в состоянии OnGroundState (ошибка? может быть OnAttachmentPlaceState).
        return dragAndDrop.draggableObjectState.GetType() == typeof(OnGroundState);
    }
}