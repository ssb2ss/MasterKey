using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButton : MonoBehaviour
{

    public Image[] keyImage;
    public string keyImageCode;

    public void SetKeyImage(string index)
    {
        keyImageCode = index;
        for (int i = 0; i < 3; i++)
        {
            if(index[i] == '0')
            {
                keyImage[i].sprite = GameManager.instance.keySprite[0];
            }
            else if(index[i] == '1')
            {
                keyImage[i].sprite = GameManager.instance.keySprite[1];
            }
            else if (index[i] == '2')
            {
                keyImage[i].sprite = GameManager.instance.keySprite[2];
            }
            else if (index[i] == '3')
            {
                keyImage[i].sprite = GameManager.instance.keySprite[3];
            }
            else if (index[i] == '4')
            {
                keyImage[i].sprite = GameManager.instance.keySpriteTop;
            }
        }
    }

}
