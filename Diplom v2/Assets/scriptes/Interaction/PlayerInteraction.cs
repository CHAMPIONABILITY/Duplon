using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 10f;

    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
	{
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactionDistance))
		{
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
                    interactable.Interact();
				}
			}
		}
	}
}
