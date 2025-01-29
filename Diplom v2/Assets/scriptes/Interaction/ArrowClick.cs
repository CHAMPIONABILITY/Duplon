using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClick : MonoBehaviour, Interactable
{
    [Header("Links")]
    public MapGenerator perlinEmpty;
    public TextMesh value;

    [Header("Incrise / Dectrise")]
    public bool isVector = true;
    int vec;

    [Header("Mesh parametr")]
    public bool isMapChunkSize;
    public bool isLevelOfDetails;
    public bool isNoiseScale;
    public bool isOctaves;
    public bool isPersistence;
    public bool isLacunarity;
    public bool isSeed;
    public bool isMeshHeightMultiplier;
    public bool isGenerate;


    void Start()
    {
        if (isMapChunkSize)
        {
            value.text = perlinEmpty.mapChunkSize.ToString();
        }
        else if (isLevelOfDetails)
        {
            value.text = perlinEmpty.levelOflDetails.ToString();
        }
        else if (isNoiseScale)
        {
            value.text = perlinEmpty.noiseScale.ToString();
        }
        else if (isOctaves)
        {
            value.text = perlinEmpty.octaves.ToString();
        }
        else if (isPersistence)
        {
            value.text = perlinEmpty.persistence.ToString();
        }
        else if (isLacunarity)
        {
            value.text = perlinEmpty.lacunarity.ToString();
        }
        else if (isSeed)
        {
            value.text = perlinEmpty.seed.ToString();
        }
        else if (isMeshHeightMultiplier)
        {
            value.text = perlinEmpty.meshHeightMultiplier.ToString();
        }

        if (isVector)
        {
            vec = 1;
        }
        else
        {
            vec = -1;
        }
    }

    public void Interact()
    {
        if (isMapChunkSize)
        {
            perlinEmpty.mapChunkSize += vec;
            value.text = perlinEmpty.mapChunkSize.ToString();
        }
        else if (isLevelOfDetails)
        {
            perlinEmpty.levelOflDetails += vec;
            value.text = perlinEmpty.levelOflDetails.ToString();
        }
        else if (isNoiseScale)
        {
            perlinEmpty.noiseScale += vec * 0.1f;
            value.text = perlinEmpty.noiseScale.ToString();
        }
        else if (isOctaves)
        {
            perlinEmpty.octaves += vec;
            value.text = perlinEmpty.octaves.ToString();
        }
        else if (isPersistence)
        {
            perlinEmpty.persistence += vec * 0.01f;
            value.text = perlinEmpty.persistence.ToString();
        }
        else if (isLacunarity)
        {
            perlinEmpty.lacunarity += vec * 0.1f;
            value.text = perlinEmpty.lacunarity.ToString();
        }
        else if (isSeed)
        {
            perlinEmpty.seed += vec;
            value.text = perlinEmpty.seed.ToString();
        }
        else if (isMeshHeightMultiplier)
        {
            perlinEmpty.meshHeightMultiplier += vec * 0.1f;
            value.text = perlinEmpty.meshHeightMultiplier.ToString();
        }
        else if (isGenerate)
		{
            perlinEmpty.GenerateMap();
		}
    }
}
