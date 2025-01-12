using UnityEngine;

[CreateAssetMenu(fileName = "ScrollAreaConfig", menuName = "CONFIGURATIONS/Camera/ScrollAreaConfig", order = 0)]
public class ScrollAreaConfig : ScriptableObject
{
    [field: SerializeField, Range(0f, 600f)] public float areaWidth { get; private set; }
}