using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGAMEOVER : GameFSMState
{

    public override void BeginState()
    {
        base.BeginState();

        Debug.Log("GameOver");
    }

}
