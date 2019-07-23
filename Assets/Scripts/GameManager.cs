using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Sprite[] keySpirte;

    private int score;
    private int[] currentKeyShape;

    private void Awake()
    {
        currentKeyShape = new int[8];
    }

    public void SetKeyShape()
    {
        for (int i = 0; i < 8; i++)
        {
            currentKeyShape[i] = Random.Range(0, 4);
        }
    }

    public void OnKeySelected(int index)
    {
        Debug.Log(index);
    }

}
