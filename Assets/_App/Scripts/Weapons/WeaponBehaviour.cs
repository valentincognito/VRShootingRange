using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBehaviour : MonoBehaviour
{
    public Transform magazineClip;
    public Text targetInfoDisplay;

    //to clean
    public Transform crosshair;

    [SerializeField]
    private GameObject ammoStock;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    [SerializeField]
    private ParticleSystem smoke;
    [SerializeField]
    private MagazineBehaviour magazineBehaviour;

    private RaycastHit hit;

    private void Update()
    {
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit))
        {
            targetInfoDisplay.text = hit.transform.name.ToString();

            crosshair.position = hit.point;
            //Debug.DrawRay(hit.point, spawnPoint.transform.forward, Color.red);
        }
        
    }

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
            smoke.Play();

            magazineBehaviour.DiscardBullet();

            

            if(Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
            }
            
        }

    }

    
}
