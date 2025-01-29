using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject outPosition;
    public Camera outCam;
    bool off;

	private void Update()
	{

    }

	private void OnTriggerEnter(Collider other)
    {
        if (!off)
        {
            Transform casperBody = other.transform;
            casperBody.transform.RotateAround(transform.position, new Vector3(0f, 1f, 0f), outCam.GetComponent<PortalCamB>().angel);
            Vector3 relative = casperBody.position - transform.position;

            outPosition.GetComponent<Portal>().off = true;
            Vector3 newPos = outPosition.transform.position + relative;
            other.transform.position = newPos;

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Camera.main.GetComponent<CameraRot>().yRotation += outCam.GetComponent<PortalCamB>().angel;
            Camera.main.GetComponent<CameraRot>().rotateCamera();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (off)
            off = false;
    }

}
