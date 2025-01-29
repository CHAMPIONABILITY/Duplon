using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClickOffset : MonoBehaviour, Interactable
{
    [Header("Links")]
    public MapGenerator perlinEmpty;
    public TextMesh value;

    [Header("Incrise / Dectrise")]
    public bool isVector = true;

    [Header("Mesh offset vector")]
    public bool isForward;
    public bool isLeft;
    public bool isBack;
    public bool isRight;

    void Start()
    {
        value.text = $"x: {perlinEmpty.offset.x}\ny: {perlinEmpty.offset.y}";
    }

    public void Interact()
    {
        if (isForward)
        {
            perlinEmpty.offset.x += 0.1f;
            value.text = $"x: {perlinEmpty.offset.x}\ny: {perlinEmpty.offset.y}";
        }
        else if (isBack)
        {
            perlinEmpty.offset.x -= 0.1f;
            value.text = $"x: {perlinEmpty.offset.x}\ny: {perlinEmpty.offset.y}";
        }
        else if (isLeft)
        {
            perlinEmpty.offset.y += 0.1f;
            value.text = $"x: {perlinEmpty.offset.x}\ny: {perlinEmpty.offset.y}";
        }
        else if (isRight)
        {
            perlinEmpty.offset.y -= 0.1f;
            value.text = $"x: {perlinEmpty.offset.x}\ny: {perlinEmpty.offset.y}";
        }
    }
}
