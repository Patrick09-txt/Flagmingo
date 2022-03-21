using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/Text")]
public class TextDataSO : ScriptableObject
{
    [SerializeField] public string YouHaveFlag;
    [SerializeField] public string EnemyHasFlag;
    [SerializeField] public string YouWonRound;
    [SerializeField] public string EnemyWonRound;
    [SerializeField] public string YouWonGame;
    [SerializeField] public string EnemyWonGame;
}
