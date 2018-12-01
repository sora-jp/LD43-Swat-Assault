using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensX, sensY;

    public static Vector2 ViewportCenter => Vector2.one * 0.5f;
    public static Camera CurrentCamera { get; private set; }
    public static Ray GetPointerRay() => CurrentCamera.ViewportPointToRay(ViewportCenter);

    private void Awake()
    {
        CurrentCamera = GetComponent<Camera>();
    }

    void Update()
    {
        // Y axis rotation is handled by PlayerController in order to rotate the entire body ( to simplify input rotation ) so only rotate X axis
        Vector3 eu = transform.localRotation.eulerAngles;
        eu.x -= Input.GetAxisRaw("Mouse Y") * sensY;
        transform.localRotation = Quaternion.Euler(eu);
    }
}
