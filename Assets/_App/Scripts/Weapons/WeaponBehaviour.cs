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
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            bullet.transform.parent = spawnPoint.transform;
            bullet.transform.position = spawnPoint.position;
            bullet.transform.localEulerAngles = new Vector3(90, 0, 0);
            rb.isKinematic = false;
            rb.velocity = spawnPoint.transform.forward * velocity;
            bullet.transform.parent = GameObject.FindWithTag("Projectiles").transform;
            bullet.gameObject.SetActive(true);
        }

    }
}
