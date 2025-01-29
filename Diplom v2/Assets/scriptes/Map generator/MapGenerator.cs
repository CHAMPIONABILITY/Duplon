using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColorMap, Mesh};
    public DrawMode drawMode;

    public int mapChunkSize = 241;
    [Range(0,6)]
    public int levelOflDetails;
    public float noiseScale;

    public int octaves;
    [Range(0, 2)]
    public float persistence;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    public bool autoUpdate;

    public TerrainType[] regions;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistence, lacunarity, offset);

        Color[] colorMap = new Color[mapChunkSize * mapChunkSize];
        for (int y = 0; y < mapChunkSize; y++)
        {
            for (int x = 0; x < mapChunkSize; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if(currentHeight <= regions[i].height)
                    {
                        colorMap[y * mapChunkSize + x] = regions[i].color;
                        break;
                    }
                }
            }
        }

        NoiseDisplay display = FindObjectOfType<NoiseDisplay>();

        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeigthMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColorMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapChunkSize, mapChunkSize));
        }
        else if(drawMode == DrawMode.Mesh)
		{
            display.DrawMesh(MeshGenerator.GenerateTerrainMash(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOflDetails), TextureGenerator.TextureFromColorMap(colorMap, mapChunkSize, mapChunkSize));
        }

    }

    private void OnValidate()
    {
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
        if(offset.x > 1000000)
		{
            offset.x = 1000000;
        }
        if (offset.x < -1000000)
        {
            offset.x = -1000000;
        }
        if (offset.y > 1000000)
        {
            offset.y = 1000000;
        }
        if (offset.y < -1000000)
        {
            offset.y = -1000000;
        }
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    [Range(0, 1)]
    public float height;
    public Color color;
}