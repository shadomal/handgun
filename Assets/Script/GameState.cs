﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum STATE_GAME
    {
        INITIALIZING,
        READY_TO_GO,
        ROLLING_DICES,
        STARTING,
        CHECKING_DICES,
        SPAWNPLAYER,
        START_TURN,
        REBOOTING, 
    }
}
