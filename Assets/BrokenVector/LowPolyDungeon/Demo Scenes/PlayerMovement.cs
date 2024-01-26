using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float rotSpeed = 1f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;


    float speedBoost = 1f;
    Vector3 velocity;
    void Start()
    {

    }

    void Update()
    {
        if (GameStateMachine.Instance.state != GameStateMachine.GameState.Gameplay)
            return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward*z;

        controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);

        transform.Rotate(Vector3.up * .1f * x * rotSpeed);
    }
}
