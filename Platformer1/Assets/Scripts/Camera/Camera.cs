using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target; // The player object to follow
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Vector2 minPosition; // Minimum camera position
    public Vector2 maxPosition; // Maximum camera position

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            Vector3 clampedPosition = new Vector3(Mathf.Clamp(smoothedPosition.x, minPosition.x, maxPosition.x),
                                                  Mathf.Clamp(smoothedPosition.y, minPosition.y, maxPosition.y),
                                                  transform.position.z);

            transform.position = clampedPosition;
        }
    }
}
