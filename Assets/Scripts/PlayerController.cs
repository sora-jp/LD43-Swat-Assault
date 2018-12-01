using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed, hSpeed, vSpeed, gravity, jumpForce;
    public LayerMask groundCheck;

    CharacterController controller;
    CameraController cameraController;

    float velY;

    bool isGrounded;
    bool canJump;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraController = GetComponentInChildren<CameraController>();
    }

    void Update()
    {
        // Movement
        Vector3 mDelta = GetMovementVector();
        mDelta = transform.rotation * mDelta; // Rotate vector ( so W actually moves in the direction which we are facing )
        mDelta += Vector3.up * velY;
        CollisionFlags col = GetComponent<CharacterController>().Move(mDelta * Time.deltaTime);

        // Collision Handling
        isGrounded = col.HasFlag(CollisionFlags.Below);

        // Gravity
        if (isGrounded) velY = -0.1f;
        else velY -= gravity * Time.deltaTime;

        // Jumping
        if (isGrounded) canJump = true;
        if (canJump && Input.GetKeyDown(KeyCode.Space)) velY = jumpForce;

        // Rotation
        Vector3 eu = transform.rotation.eulerAngles;
        eu.y += Input.GetAxisRaw("Mouse X") * cameraController.sensX;
        transform.rotation = Quaternion.Euler(eu);
    }

    Vector3 GetMovementVector() => new Vector3(Input.GetAxisRaw("Horizontal") * hSpeed, 0, Input.GetAxisRaw("Vertical") * vSpeed) * moveSpeed;
}
