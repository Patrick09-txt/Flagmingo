using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win
{
    public PlayerNumber playerNumber;
    public int Round { get; set; }

    public Win(PlayerNumber playerNumber, int round)
    {
        this.playerNumber = playerNumber;
        Round = round;
    }
}
