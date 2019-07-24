using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSELECT : GameFSMState
{

    public GameObject lockBody, key, keySide;
    public GameObject selectBox;
    public GameObject keySilhouette;
    
    private int currentPiece;

    public override void BeginState()
    {
        base.BeginState();

        keySide.SetActive(false);
        lockBody.transform.position = new Vector3(-3.87f, 7.67f, lockBody.transform.position.z);
        key.transform.position = new Vector3(-3.87f, -8.19f, key.transform.position.z);
        lockBody.transform.rotation = Quaternion.Euler(0, 0, 0);
        key.transform.rotation = Quaternion.Euler(0, 0, 0);
        keySilhouette.SetActive(true);
        key.SetActive(true);
        StartCoroutine("FadeIn");

        GameManager.instance.SetKeyShape();
        for(int i = 0; i < 3; i++)
        {
            GameManager.instance.keyPiece[i].SetActive(false);
        }
        for(int i = 0; i < 6; i++)
        {
            GameManager.instance.buttonManager.button[i].SetActive(true);
        }
        currentPiece = 0;
        selectBox.SetActive(true);
        SetSelectedBox();
        GameManager.instance.SetButtons(GetRealKey(), currentPiece);
    }

    private IEnumerator FadeIn()
    {
        for(int i = 0; i < 20; i++)
        {
            lockBody.transform.Translate(Vector3.down * 0.25f);
            key.transform.Translate(Vector3.up * 0.25f);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    public void OnKeyButtonClick(int idx)
    {
        string selectedPiece = GameManager.instance.buttonManager.button[idx].GetComponent<SetButton>().keyImageCode;
        GameManager.instance.SetPieceImage(selectedPiece, currentPiece);
        currentPiece++;
        if (currentPiece == 3)
        {
            string tem1 = GameManager.instance.keyPiece[0].GetComponent<KeyPiece>().piece;
            string tem2 = GameManager.instance.keyPiece[1].GetComponent<KeyPiece>().piece;
            string tem3 = GameManager.instance.keyPiece[2].GetComponent<KeyPiece>().piece;
            GameManager.instance.SetCurrentKeyShape(tem1 + tem2 + tem3);
            selectBox.SetActive(false);
            GameManager.instance.SetState(GameState.INSERT);
            return;
        }
        SetSelectedBox();
        GameManager.instance.SetButtons(GetRealKey(), currentPiece);
    }

    private void SetSelectedBox()
    {
        if(currentPiece == 0)
        {
            selectBox.transform.position = new Vector3(-3.88f, -3.94f, 0);
        }
        else if(currentPiece == 1)
        {
            selectBox.transform.position = new Vector3(-3.88f, -2.44f, 0);
        }
        else if (currentPiece == 2)
        {
            selectBox.transform.position = new Vector3(-3.88f, -0.94f, 0);
        }
    }

    private string GetRealKey()
    {
        string realkey = "";
        int tem1 = GameManager.instance.realKeyShape[3 * currentPiece];
        int tem2 = GameManager.instance.realKeyShape[3 * currentPiece + 1];
        int tem3 = GameManager.instance.realKeyShape[3 * currentPiece + 2];
        realkey = "" + tem1 + tem2 + tem3;
        return realkey;
    }

}