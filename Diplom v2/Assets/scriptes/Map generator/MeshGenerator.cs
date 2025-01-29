using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator
{
    public static MeshData GenerateTerrainMash(float[,] heigthMap,  float heightMultiplier, AnimationCurve heightCurve, int levelDetail)
	{
		int widht = heigthMap.GetLength(0);
		int heigth = heigthMap.GetLength(1);

		float topLeftX = (widht - 1) / -2f;
		float topLeftZ = (heigth - 1) / 2f;

		int meshSimpleficationIncrement = levelDetail == 0 ? 1 : levelDetail * 2;
		int verticesPerline = (widht - 1) / meshSimpleficationIncrement + 1;

		MeshData meshData = new MeshData(verticesPerline, verticesPerline);
		int vertexIndex = 0;

		for(int y = 0; y < heigth; y += meshSimpleficationIncrement)
		{
			for(int x = 0; x < widht; x += meshSimpleficationIncrement)
			{
				meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, heightCurve.Evaluate(heigthMap[x, y]) * heightMultiplier, topLeftZ - y);
				meshData.uvs[vertexIndex] = new Vector2(x / (float)widht, y / (float)heigth);

				if (x < widht - 1 && y < heigth - 1)
				{
					meshData.AddTriangle(vertexIndex, vertexIndex + verticesPerline + 1, vertexIndex + verticesPerline);
					meshData.AddTriangle(vertexIndex + verticesPerline + 1, vertexIndex, vertexIndex + 1);
				}

				vertexIndex++;
			}
		}

		return meshData;
	}
}

public class MeshData
{
	public Vector3[] vertices;
	public int[] triangles;
	public Vector2[] uvs;

	int triangleIndex;

	public MeshData(int meshWidth, int meshHeight)
	{
		vertices = new Vector3[meshWidth * meshHeight];
		uvs = new Vector2[meshWidth * meshHeight];
		triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
	}

	public void AddTriangle(int a, int b, int c)
	{
		triangles[triangleIndex] = a;
		triangles[triangleIndex + 1] = b;
		triangles[triangleIndex + 2] = c;
		triangleIndex += 3;
	}

	public Mesh CreateMesh()
	{
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;
		mesh.RecalculateNormals();
		return mesh;
	}
}