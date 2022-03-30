using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagCarrier : MonoBehaviour
{
    public bool HasFlag = false;

    [SerializeField] private PlayerNumber playerNumber;
    private FlagWinArea winArea;
    private float distanceToWinArea;
    private WinManager winManager;

    private bool called = false;

    [field: SerializeField] public UnityEvent OnWinAreaEnter { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        winManager = GameObject.FindGameObjectWithTag("WinManager")?.GetComponent<WinManager>();

        GameObject[] winAreas = GameObject.FindGameObjectsWithTag("WinArea");
        foreach (GameObject a in winAreas)
        {
            FlagWinArea w = a.GetComponent<FlagWinArea>();
            if (w.PlayerCorner == playerNumber)
            {
                winArea = w;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceToWinArea = Vector2.Distance(transform.position, winArea.transform.position);

        if (!called)
        {
            if (distanceToWinArea < winArea.WinAreaSize)
            {
                called = true;

                //Debug.Log("Player entered their own win area!");
                OnWinAreaEnter?.Invoke();

                if (HasFlag)
                {
                    winManager.NewWin(playerNumber);
                }
            }
        }
        else
        {
            if (distanceToWinArea > winArea.WinAreaSize)
            {
                called = false;
            }
        }
    }

    public void Flag(bool hasFlag)
    {
        HasFlag = hasFlag;
    }
}
