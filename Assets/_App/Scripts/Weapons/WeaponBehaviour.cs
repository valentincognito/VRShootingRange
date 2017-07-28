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
        Transform bullet = ammoStock.transform.GetChild(0);

        if (bullet)
        {
            bullet.transform.position = spawnPoint.position;
            //bullet.transform.rotation = spawnPoint.localRotation;
            bullet.GetComponent<Rigidbody>().isKinematic = false;
            bullet.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * 5f;  
            bullet.transform.parent = GameObject.FindWithTag("Projectiles").transform;
            bullet.gameObject.SetActive(true);
        }
        

    }
}
