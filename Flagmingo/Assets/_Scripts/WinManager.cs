using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinManager : MonoBehaviour
{
    public List<Win> winList = new List<Win>();

    [Range(1, 10)] public int rounds = 3;
    public int currentRound = 0;

    [field: SerializeField] public UnityEvent OnRoundWin { get; set; }
    [field: SerializeField] public UnityEvent OnGameWin { get; set; }

    public void NewWin(PlayerNumber player)
    {
        winList.Add(new Win(player, currentRound));
        currentRound++;

        if (winList.Count >= rounds)
        {
            Debug.Log($"<color=red>Player {player} won the game!!</color>");
            OnGameWin?.Invoke();
        }
        else
        {
            Debug.Log($"<color=yellow>Player {player} won round {currentRound}!</color>");
            OnRoundWin?.Invoke();
        }
    }
}
