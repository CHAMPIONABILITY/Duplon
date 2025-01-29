using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrientation : MonoBehaviour
{
    public float xRot;
    public float yRot;
    public float zRot;

    public float gravityForce = 9.81f;

    public Vector3 gravityDirection;

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        xRot = 0;
        yRot = 0;
        zRot = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            xRot = 1;
            yRot = 0;
            zRot = 0;
            gravityDirection = new Vector3(xRot, yRot, zRot) * gravityForce;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            xRot = -1;
            yRot = 0;
            zRot = 0;
            gravityDirection = new Vector3(xRot, yRot, zRot) * gravityForce;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            xRot = 0;
            yRot = 1;
            zRot = 0;
            gravityDirection = new Vector3(xRot, yRot, zRot) * gravityForce;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            xRot = 0;
            yRot = -1;
            zRot = 0;
            gravityDirection = new Vector3(xRot, yRot, zRot) * gravityForce;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            xRot = 0;
            yRot = 0;
            zRot = 1;
            gravityDirection = new Vector3(xRot, yRot, zRot) * gravityForce;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            xRot = 0;
            yRot = 0;
            zRot = -1;
            gravityDirection = new Vector3(xRot, yRot, zRot) * gravityForce;
        }
        rb.AddForce(gravityDirection, ForceMode.Acceleration);
    }
}
