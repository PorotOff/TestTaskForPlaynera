using UnityEngine;

[CreateAssetMenu(fileName = "DragAreaConfig", menuName = "CONFIGURATIONS/Camera/DragAreaConfig", order = 0)]
public class DragAreaConfig : ScriptableObject
{
    [field: SerializeField, Range(-1f, 1f)] public float cameraScrollingXOffset { get; private set; }
}