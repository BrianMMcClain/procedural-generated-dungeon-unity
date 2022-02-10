using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xAxis;
    private float zAxis;

    public float speed = 5;

    public Camera playerCamera;

    void Start()
    {
        
    }

    void Update()
    {
        // Move
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * zAxis * speed * Time.deltaTime);
        transform.Translate(Vector3.right * xAxis * speed * Time.deltaTime);

        // Rotate
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");
        playerCamera.transform.Rotate(new Vector3(-mouseY * 10, mouseY * 10, 0));

    }
}
