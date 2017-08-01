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
    [SerializeField]
    private ParticleSystem muzzleFlash;
    [SerializeField]
    private MagazineBehaviour magazineBehaviour;

    public void Shoot()
    {
        Transform bullet = ammoStock.transform.GetChild(0);

        if (bullet)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            AudioSource shoot = GetComponent<AudioSource>();

            bullet.transform.parent = spawnPoint.transform;
            bullet.transform.position = spawnPoint.position;
            bullet.transform.localEulerAngles = new Vector3(90, 0, 0);
            rb.isKinematic = false;
            rb.velocity = spawnPoint.transform.forward * velocity;
            bullet.transform.parent = GameObject.FindWithTag("Projectiles").transform;
            bullet.gameObject.SetActive(true);

            muzzleFlash.Play();
            shoot.Play();

            magazineBehaviour.DiscardBullet();
        }

    }

    
}
