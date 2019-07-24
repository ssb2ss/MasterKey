using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGAMEOVER : GameFSMState
{

    public GameObject key, lockBody;
    public float gravityScale, rotScale;
    public GameObject gameover;

    private int moveState;
    private float currentGravity, currentRot;

    public override void BeginState()
    {
        base.BeginState();

        moveState = 0;
        currentGravity = currentRot = 0;
        gameover.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        StartCoroutine("KeyShake");
    }

    private void Update()
    {
        if (moveState == 1)
        {
            currentGravity += gravityScale;
            currentRot += rotScale;
            key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y - currentGravity, key.transform.position.z);
            lockBody.transform.position = new Vector3(lockBody.transform.position.x, lockBody.transform.position.y - currentGravity, lockBody.transform.position.z);
            key.transform.Rotate(0, 0, key.transform.rotation.z + currentRot);
            lockBody.transform.Rotate(0, 0, lockBody.transform.rotation.z + currentRot);
            gameover.GetComponent<Image>().color = new Color(1, 1, 1, gameover.GetComponent<Image>().color.a + 0.1f);
            if (lockBody.transform.position.y < -100)
            {
                gameover.SetActive(false);
                GameManager.instance.ChangeGameoverScene();
                return;
            }
        }
    }

    private IEnumerator KeyShake()
    {
        key.transform.Translate(Vector3.left * 0.05f);
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
            {
                key.transform.Translate(Vector3.right * 0.1f);
            }
            else
            {
                key.transform.Translate(Vector3.left * 0.1f);
            }
            yield return new WaitForSeconds(0.05f);
        }
        key.transform.position = new Vector3(-3.87f, key.transform.position.y, key.transform.position.z);
        yield return new WaitForSeconds(0.5f);
        gameover.SetActive(true);
        moveState = 1;
        yield return null;
    }

}
