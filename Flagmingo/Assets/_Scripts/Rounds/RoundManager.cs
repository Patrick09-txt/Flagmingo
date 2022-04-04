using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int TotalRounds { get; private set; }
    public int CurrentRound { get; private set; }
    public List<Round> Rounds { get; private set; } = new List<Round>();
    public List<PlayerRoundData> PlayerDatas { get; private set; } = new List<PlayerRoundData>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundFinished (PlayerNumber playerWon, Round round, int time)
    {

    }
}
