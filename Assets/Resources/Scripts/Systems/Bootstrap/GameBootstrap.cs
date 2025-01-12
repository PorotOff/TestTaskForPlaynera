using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [Header("Camera scrolling settings")]
    [SerializeField] private ScrollArea scrollArea;
    [SerializeField] private CameraConfig cameraConfig;
    [SerializeField] private Transform targetMoveWithinObject;

    [SerializeField] private CameraScrolling cameraScrolling;
    [SerializeField] private ScrollAreaConfig scrollAreaConfig;

    private void Awake()
    {
        // General settings
        Application.targetFrameRate = 60;

        // Camera scrolling settings

        cameraScrolling.Initialise(cameraConfig.scrollingSpeed, targetMoveWithinObject);
        scrollArea.Initialise(scrollAreaConfig.areaWidth);
    }
}