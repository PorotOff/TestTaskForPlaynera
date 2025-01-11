using UnityEngine;

[CreateAssetMenu(fileName = "CameraConfig", menuName = "CONFIGURATIONS/Camera/CameraConfig", order = 0)]
public class CameraConfig : ScriptableObject
{
    [field: SerializeField] public float scrollingSpeed { get; private set; }
}