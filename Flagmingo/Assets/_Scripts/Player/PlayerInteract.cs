using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    FlagController Flag;
    bool inFlagRange = false;
    bool flagAvailable = false;

    public GameObject objectCarrying;

    [SerializeField] private GameObject objectCarryParent;
    [SerializeField] private Vector3 objectCarryOffset;

    [field: SerializeField] public UnityEvent OnFlagAvailable { get; set; }
    [field: SerializeField] public UnityEvent OnFlagNotAvailable { get; set; }
    [field: SerializeField] public UnityEvent OnFlagPickedUp { get; set; }
    [field: SerializeField] public UnityEvent OnFlagDropped { get; set; }
    [field: SerializeField] public UnityEvent OnItemPickedUp { get; set; }

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Flag"))
        {
            Flag = col.GetComponent<FlagController>();

            if (!Flag.isBeingCarried)
            {
                inFlagRange = true;
                Debug.Log("<color=blue>Entered Flag Area</color>");
                OnFlagAvailable?.Invoke();
                flagAvailable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Flag"))
        {
            if (!Flag.isBeingCarried)
            {
                inFlagRange = false;
                Debug.Log("<color=blue>Exited Flag Area</color>");
                OnFlagNotAvailable?.Invoke();
                flagAvailable = false;
            }
        }
    }

    public void Interact()
    {
        // If you are in range of the flag, we assume that is what you want to pick up/interact with
        if (inFlagRange)
        {
            if (Flag != null)
            {
                TryPickUpFlag(Flag);
            }
        }

        else
        {
            TryPickUpItem();
        }
    }

    private void TryPickUpFlag(FlagController flag)
    {
        if (flagAvailable)
        {
            OnFlagPickedUp?.Invoke();

            flagAvailable = false;
            flag.isBeingCarried = true;

            objectCarrying = flag.gameObject;
            ObjectFollowPlayer(flag.gameObject, objectCarryParent.transform, true, objectCarryOffset, new Vector3(0, 0, 70));

            Debug.Log("<color=pink>Flag Picked Up!</color>");
        }
    }

    private void DropFlag(FlagController flag)
    {
        OnFlagDropped?.Invoke();

        flagAvailable = true;
        flag.isBeingCarried = false;

        Debug.Log("<color=pink>Flag Dropped!</color>");
    }

    private void TryPickUpItem()
    {
        OnItemPickedUp?.Invoke();
        Debug.Log("<color=pink>Item Picked Up!</color>");
    }

    private void ObjectFollowPlayer(GameObject obj, Transform parent, bool inheritRotation, Vector3 offset, Vector3 rotation)
    {
        obj.transform.parent = parent;

        obj.transform.localPosition = new Vector3(offset.x, offset.y, obj.transform.position.z);

        if (inheritRotation)
        {
            obj.transform.rotation = Quaternion.Euler(rotation);
        }
    }

    public void ObjectFlip(bool flip)
    {
        if (objectCarrying != null)
        {
            if (flip)
            {
                objectCarrying.transform.parent.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                objectCarrying.transform.parent.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(objectCarryOffset, 0.15f);
    }
}
