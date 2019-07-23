using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPiece : MonoBehaviour
{

    public SpriteRenderer[] keyPiece;
    public string piece;

    public void SetPieceImage(string selectedKey)
    {
        piece = selectedKey;
        for(int i = 0; i < 3; i++)
        {
            if (selectedKey[i] == '0')
            {
                keyPiece[i].sprite = GameManager.instance.keySprite[0];
            }
            else if (selectedKey[i] == '1')
            {
                keyPiece[i].sprite = GameManager.instance.keySprite[1];
            }
            else if (selectedKey[i] == '2')
            {
                keyPiece[i].sprite = GameManager.instance.keySprite[2];
            }
            else if (selectedKey[i] == '3')
            {
                keyPiece[i].sprite = GameManager.instance.keySprite[3];
            }
            else if (selectedKey[i] == '4')
            {
                keyPiece[i].sprite = GameManager.instance.keySpriteTop;
            }
        }
    }

}
