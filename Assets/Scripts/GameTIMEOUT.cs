﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTIMEOUT : GameFSMState
{

    public override void BeginState()
    {
        base.BeginState();

        for (int i = 0; i < 6; i++)
        {
            GameManager.instance.buttonManager.button[i].SetActive(false);
        }
    }

}