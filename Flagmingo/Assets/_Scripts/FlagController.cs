using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagController : MonoBehaviour
{
    public float FlagGrabRadius = 3;
    public bool isBeingCarried = false;

    [field: SerializeField] public UnityEvent<bool> OnFlagGrabAreaEnter { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        CircleCollider2D grabArea = gameObject.AddComponent<CircleCollider2D>();
        grabArea.offset = new Vector2(0, 0);
        grabArea.isTrigger = true;
        grabArea.radius = FlagGrabRadius;
    }

    public void PickUp()
    {
        isBeingCarried = true;
    }

    public void Drop()
    {
        isBeingCarried = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        OnFlagGrabAreaEnter?.Invoke(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FlagGrabRadius);
    }
}
