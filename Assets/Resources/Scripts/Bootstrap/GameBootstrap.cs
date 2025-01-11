using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [Header("Camera scrolling settings")]
    [SerializeField] private CameraScrolling cameraScrolling;
    [SerializeField] private CameraConfig cameraConfig;

    [SerializeField] private DragArea LeftDragArea;
    [SerializeField] private DragAreaConfig leftDragAreaConfig;
    [SerializeField] private DragArea rightDragArea;
    [SerializeField] private DragAreaConfig rightDragAreaConfig;

    private void Awake()
    {
        // Camera scrolling settings
        cameraScrolling.Initialize(cameraConfig.scrollingSpeed);
        LeftDragArea.Initialize(leftDragAreaConfig, cameraScrolling);
        rightDragArea.Initialize(rightDragAreaConfig, cameraScrolling);
    }
}