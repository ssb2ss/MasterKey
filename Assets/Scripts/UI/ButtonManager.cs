using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameObject[] button;

    public void ShuffleKeyImage(string realKey, bool isEnd)
    {
        string[] keyIndex = new string[6];
        keyIndex[Random.Range(0, 6)] = realKey;
        for(int i = 0; i < 6; i++)
        {
            if (keyIndex[i] == null)
            {
                int tem1 = Random.Range(0, 4);
                int tem2 = Random.Range(0, 4);
                int tem3;
                if (isEnd)
                    tem3 = 4;
                else
                    tem3 = Random.Range(0, 4);
                keyIndex[i] = "" + tem1 + tem2 + tem3;
            }
            button[i].GetComponent<SetButton>().SetKeyImage(keyIndex[i]);
        }
    }
    
}
