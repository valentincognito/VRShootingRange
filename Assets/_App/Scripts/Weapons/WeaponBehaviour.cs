using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ammoStock;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float velocity;

    public void Shoot()
    {
        Debug.Log("shoot");
    }
}
