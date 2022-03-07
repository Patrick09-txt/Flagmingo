using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] protected int playerSortingOrder = 0;
    protected SpriteRenderer weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool val)
    {
        int flipModifier = val ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, flipModifier * Mathf.Abs(transform.localScale.y), transform.localScale.z);

        //weaponRenderer.flipY = val; // This will result in the muzzle flash and bullets exiting the gun being off when flipped
    }

    public void RenderBehindPlayer(bool val)
    {
        if (val)
        {
            weaponRenderer.sortingOrder = playerSortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = playerSortingOrder + 1;
        }
    }
}
