using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoundData : MonoBehaviour
{
    [field: SerializeField] public int PosessionTime { get; set; }
    [field: SerializeField] public int Kills { get; set; }
    [field: SerializeField] public int Deaths { get; set; }
}
