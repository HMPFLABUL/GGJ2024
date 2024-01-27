using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardsCamera : MonoBehaviour
{
    Camera cam;
    Vector3 offset = new Vector3(0, 180, 0);
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        transform.LookAt(cam.transform);
        transform.Rotate(offset);
    }
}
