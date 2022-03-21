using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    FlagController Flag;
    bool flagAvailable = false;
    private Text_ControlSchemeDependentDataSO displayTexts;

    [field: SerializeField] public UnityEvent OnFlagAvailable { get; set; }
    [field: SerializeField] public UnityEvent OnFlagNotAvailable { get; set; }
    [field: SerializeField] public UnityEvent OnFlagPickedUp { get; set; }
    [field: SerializeField] public UnityEvent OnItemPickedUp { get; set; }

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Flag"))
        {
            Debug.Log("<color=blue>Entered Flag Area</color>");

            Flag = col.GetComponent<FlagController>();

            if (!Flag.isBeingCarried)
            {
                OnFlagAvailable?.Invoke();
                flagAvailable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Flag"))
        {
            Debug.Log("<color=blue>Exited Flag Area</color>");

            if (!Flag.isBeingCarried)
            {
                OnFlagNotAvailable?.Invoke();
                flagAvailable = false;
            }
        }
    }

    public void TryPickUpFlag()
    {
        if (flagAvailable)
        {
            OnFlagPickedUp?.Invoke();
            flagAvailable = false;
            Debug.Log("<color=pink>Flag Picked Up!</color>");
        }
    }

    public void TryPickUpItem()
    {
        OnItemPickedUp?.Invoke();
        Debug.Log("<color=pink>Item Picked Up!</color>");
    }
}
