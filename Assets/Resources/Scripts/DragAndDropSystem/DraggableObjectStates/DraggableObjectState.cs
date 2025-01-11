using UnityEngine;

public abstract class DraggableObjectState
{
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnStay();
}