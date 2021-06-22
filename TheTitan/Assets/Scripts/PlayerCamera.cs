using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform PlayerToFollow;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - PlayerToFollow.position;
    }

    // LateUpdate is called after Update method
    void LateUpdate()
    {
        //kameranýn karakteri takip etmesi için
        Vector3 newPos = PlayerToFollow.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
}
