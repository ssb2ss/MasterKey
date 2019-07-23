using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    SELECT = 0,
    INSERT
}

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int score;
    public int[] realKeyShape;
    public int[] currentKeyShape;

    public GameState stratState;
    public GameState currentState;

    public Sprite[] keySprite;
    public Sprite keySpriteTop;
    public SpriteRenderer[] keySilhouette;
    public ButtonManager buttonManager;
    public GameObject[] keyPiece;

    private Dictionary<GameState, GameFSMState> states;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        realKeyShape = new int[9];
        currentKeyShape = new int[9];
        states = new Dictionary<GameState, GameFSMState>();

        states.Add(GameState.SELECT, GetComponent<GameSELECT>());
        states.Add(GameState.INSERT, GetComponent<GameINSERT>());
    }

    private void Start()
    {
        SetState(stratState);
    }

    public void SetState(GameState newState)
    {
        foreach(GameFSMState fsm in states.Values)
        {
            fsm.enabled = false;
        }

        currentState = newState;
        states[newState].enabled = true;
        states[newState].BeginState();
    }

    public void SetKeyShape()
    {
        for (int i = 0; i < 8; i++)
        {
            realKeyShape[i] = Random.Range(0, 4);
            keySilhouette[i].sprite = keySprite[realKeyShape[i]];
        }
        realKeyShape[8] = 4;
    }

    public void SetPieceImage(string selectedPiece, int currentPiece)
    {
        keyPiece[currentPiece].SetActive(true);
        keyPiece[currentPiece].GetComponent<KeyPiece>().SetPieceImage(selectedPiece);
    }

    public void SetButtons(string realKey, int currentPiece)
    {
        if(currentPiece == 2)
        {
            buttonManager.ShuffleKeyImage(realKey, true);
        }
        else
        {
            buttonManager.ShuffleKeyImage(realKey, false);
        }
    }

    public void SetCurrentKeyShape(string key)
    {
        for(int i = 0; i < 8; i++)
        {
            if(key[i] == '0')
            {
                currentKeyShape[i] = 0;
            }
            else if (key[i] == '1')
            {
                currentKeyShape[i] = 1;
            }
            else if (key[i] == '2')
            {
                currentKeyShape[i] = 2;
            }
            else if (key[i] == '3')
            {
                currentKeyShape[i] = 3;
            }
            else if (key[i] == '4')
            {
                currentKeyShape[i] = 4;
            }
        }
    }

}
