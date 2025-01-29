using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseDisplay : MonoBehaviour
{
    public Renderer textureRender;
	public GameObject meshObj;

    public void DrawTexture(Texture2D texture)
	{
		textureRender.sharedMaterial.mainTexture = texture;
		textureRender.transform.localScale = new Vector3(texture.width / 50, 1, texture.height / 50);
	}

	public void DrawMesh(MeshData meshData, Texture2D texture)
	{
		meshObj.GetComponent<MeshFilter>().sharedMesh = meshData.CreateMesh();
		meshObj.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = texture;
		if (meshObj.GetComponent<MeshCollider>())
		{
			DestroyImmediate(meshObj.GetComponent<MeshCollider>());
			meshObj.AddComponent<MeshCollider>();
		}
	}
}
