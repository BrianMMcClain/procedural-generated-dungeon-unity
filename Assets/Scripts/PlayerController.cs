using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xAxis;
    private float zAxis;
    private float rotation;

    public float speed = 5;
    public float sensitivity = 5;

    public Camera playerCamera;

    void Start()
    {
        rotation = 0;
    }

    void Update()
    {
        // Move
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * zAxis * speed * Time.deltaTime);
        transform.Translate(Vector3.right * xAxis * speed * Time.deltaTime);

        // Rotate
        rotation += -Input.GetAxis("Mouse Y") * sensitivity;
        playerCamera.transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);

    }
}
