using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [field: SerializeField] public float SpawnAreaSize1 { get; set; } = 5;
    [field: SerializeField] public float SpawnAreaSize2 { get; set; } = 2;
    [SerializeField] public Gizmo SpawnPointGizmo = Gizmo.Sphere;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (SpawnPointGizmo == Gizmo.Sphere)
        {
            Gizmos.DrawWireSphere(transform.position, SpawnAreaSize1);
        }
        else
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(SpawnAreaSize1, SpawnAreaSize2, 1));
        }
    }

    public enum Gizmo
    {
        Sphere,
        Rectangle
    }
}