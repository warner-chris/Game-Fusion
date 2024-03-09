using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationEnd;
    [SerializeField] private float rotationEnd2;
    private bool rotateLeft = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rotateLeft)
        {
            rb.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

            if (rb.transform.localEulerAngles.z >= rotationEnd && rb.transform.localEulerAngles.z < 300)
            {
                rotateLeft = false;
            }
        }

        else
        {
            rb.transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));

            if (rb.transform.localEulerAngles.z <= (360 - rotationEnd) && rb.transform.localEulerAngles.z > (300))
            {
                rotateLeft = true;
            }
        }
    }
}
