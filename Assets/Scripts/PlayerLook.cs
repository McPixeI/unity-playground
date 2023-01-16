using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculate cam rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotate player to look left and right
        transform.Rotate(Vector2.up * (mouseX * Time.deltaTime) * xSensitivity);

    }

}
