using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 Dir;
    [SerializeField] float speed;

    private void FixedUpdate()
    {
        transform.Rotate(Dir, speed*Time.deltaTime);
    }
}
