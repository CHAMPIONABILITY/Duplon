using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamB : MonoBehaviour
{
    public Transform portalIn, portalOut, mainCam;

    public Shader camCutter;

    public Vector3 axisSnap;
    public float angel;

    void Start()
    {
        SetupRenderTexture();
    }

    void Update()
    {
        Offset();
    }

    void SetupRenderTexture()
    {
        Camera cam = GetComponent<Camera>();
        if (cam.targetTexture != null)
            cam.targetTexture.Release();

        portalIn.GetComponent<MeshRenderer>().material.shader = camCutter;

        RenderTexture tex = new RenderTexture(Screen.width, Screen.height, 24);
        cam.targetTexture = tex;

        portalIn.GetComponent<MeshRenderer>().material.mainTexture = tex;
    }

    void Offset()
	{
        Vector3 playerOffset = mainCam.position - portalIn.position;
        transform.position = portalOut.position + playerOffset;

        float angelOffset = Quaternion.Angle(portalIn.rotation, portalIn.rotation);

        Quaternion portalAngelOffset = Quaternion.AngleAxis(angelOffset, Vector3.up);
        Vector3 newCamDirection = portalAngelOffset * mainCam.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);

        transform.RotateAround(portalOut.position, axisSnap, angel);
    }

}
