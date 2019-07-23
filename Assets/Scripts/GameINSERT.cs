using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameINSERT : GameFSMState
{

    public GameObject lockBody, lockHead, key;
    public GameObject keySilhouette, keySide;
    public float moveSpeed;

    private int moveState;

    public override void BeginState()
    {
        base.BeginState();
        
        for (int i = 0; i < 6; i++)
        {
            GameManager.instance.buttonManager.button[i].SetActive(false);
        }
        moveState = 0;
        Debug.Log("insert key");
    }

    private void Update()
    {
        if (moveState == 0)
        {
            Moving();
        }
        else if (moveState == 1)
        {
            GameOverCheck();
            moveState = 2;
        }
        else if (moveState == 2)
        {
            ScoreUp();
        }
        else if (moveState == 4)
        {
            Clear();
        }
    }

    private void Moving()
    {
        lockBody.transform.position = Vector3.Lerp(
                lockBody.transform.position,
                new Vector3(lockBody.transform.position.x, 0, lockBody.transform.position.z),
                moveSpeed * Time.deltaTime);
        key.transform.position = Vector3.Lerp(
            key.transform.position,
            new Vector3(key.transform.position.x, -1.05f, key.transform.position.z),
            moveSpeed * Time.deltaTime);

        if (lockBody.transform.position.y <= 0.01f)
        {
            lockBody.transform.position = new Vector3(lockBody.transform.position.x, 0, lockBody.transform.position.z);
            key.transform.position = new Vector3(key.transform.position.x, -1.05f, key.transform.position.z);
            moveState = 1;
        }
    }

    private void GameOverCheck()
    {
        for (int i = 0; i < 8; i++)
        {
            if (GameManager.instance.currentKeyShape[i] != GameManager.instance.realKeyShape[i])
            {
                GameManager.instance.SetState(GameState.GAMEOVER);
                return;
            }
        }
    }

    private void ScoreUp()
    {
        GameManager.instance.score++;
        keySilhouette.SetActive(false);
        keySide.transform.position = new Vector3(key.transform.position.x + 0.15f, key.transform.position.y - 0.53f, keySide.transform.position.z);
        key.SetActive(false);
        keySide.SetActive(true);
        StartCoroutine("LockHeadUp");
        moveState = 3;
    }

    private void Clear()
    {
        lockBody.transform.position = Vector3.Lerp(
            lockBody.transform.position,
            new Vector3(-12f, lockBody.transform.position.y, lockBody.transform.position.z),
            moveSpeed * 2 * Time.deltaTime);
        keySide.transform.position = Vector3.Lerp(
            keySide.transform.position,
            new Vector3(-12f, keySide.transform.position.y, keySide.transform.position.z),
            moveSpeed * 2 * Time.deltaTime);
        
        if(lockBody.transform.position.x < -11)
        {
            GameManager.instance.SetState(GameState.SELECT);
            return;
        }
    }

    private IEnumerator LockHeadUp()
    {
        for(int i = 0; i < 20; i++)
        {
            lockHead.transform.position = new Vector3(lockHead.transform.position.x, lockHead.transform.position.y + 0.05f, lockHead.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        moveState = 4;
        yield return null;
    }

}