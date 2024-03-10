using UnityEngine;

public class SinglePointCamera : MonoBehaviour
{
    public Transform target; // The point the camera should focus on
    public float smoothSpeed = 0.125f; // How quickly the camera moves to its target
    public float desiredOrthographicSize = 5f; // Desired orthographic size of the camera

    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        if (mainCamera == null)
        {
            Debug.LogError("This script requires a Camera component attached to the same GameObject.");
            enabled = false;
            return;
        }

        AdjustCameraSize();
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target not assigned.");
            return;
        }

        Vector3 desiredPosition = target.position; // Get the position of the target
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly interpolate towards the target's position
        transform.position = smoothedPosition; // Update the camera's position
    }

    void AdjustCameraSize()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        float targetAspect = mainCamera.aspect;

        // If screen aspect is wider than the target aspect, adjust the camera's orthographic size accordingly
        if (screenAspect >= targetAspect)
        {
            mainCamera.orthographicSize = desiredOrthographicSize;
        }
        else // If screen aspect is taller than the target aspect, adjust the orthographic size based on the aspect ratio
        {
            mainCamera.orthographicSize = desiredOrthographicSize * (targetAspect / screenAspect);
        }
    }
}
