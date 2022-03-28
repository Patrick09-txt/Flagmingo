using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagWinArea : MonoBehaviour
{
    [Header("Player Specific Settings")]
    public PlayerNumber PlayerCorner;

    [SerializeField] private Color winAreaColor = Color.blue;
    [field: SerializeField] public float WinAreaSize { get; set; } = 5;

    // Start is called before the first frame update
    void Awake()
    {
        CircleCollider2D winArea = gameObject.AddComponent<CircleCollider2D>();
        winArea.offset = new Vector2(0, 0);
        winArea.isTrigger = true;
        winArea.radius = WinAreaSize;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = winAreaColor;
        Gizmos.DrawWireSphere(transform.position, WinAreaSize);
    }
}
