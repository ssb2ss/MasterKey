using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameObject[] button;

    public void ShuffleKeyImage(string realKey, bool isEnd)
    {
        string[] keyIndex = new string[6];
        int realKeyIndex = Random.Range(0, 6);
        keyIndex[realKeyIndex] = realKey;
        for(int i = 0; i < 6;)
        {
            if (i == realKeyIndex)
            {
                button[i].GetComponent<SetButton>().SetKeyImage(keyIndex[i]);
                i++;
                continue;
            }
            else
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

            if(keyIndex[i] == realKey)
                continue;

            bool isWrong = false;
            for(int j = 0; j < i; j++)
            {
                if(keyIndex[i] == keyIndex[j])
                {
                    isWrong = true;
                    break;
                }
            }
            if (isWrong)
                continue;

            button[i].GetComponent<SetButton>().SetKeyImage(keyIndex[i]);
            i++;
        }
    }
    
}
