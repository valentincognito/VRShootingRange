using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineBehaviour : MonoBehaviour {

    public Text bulletsCountDisplay;
    public Text magazineCapacityDisplay;

    public float clipLimit;

    [SerializeField]
    private int magazineCapacity;
    [SerializeField]
    private int bulletsCount;
    [SerializeField]
    private WeaponBehaviour weaponBehaviour;

    private OVRGrabbable ovrGrabbable;
    private AudioSource clipSound;


    public bool isClipped;
    public float distance;

    private void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();

        clipSound = GetComponent<AudioSource>();

        magazineCapacityDisplay.text = magazineCapacity.ToString();
        bulletsCountDisplay.text = bulletsCount.ToString();
    }

    private void Update()
    {
        if (ovrGrabbable.isGrabbed && !isClipped)
        {
            distance = (weaponBehaviour.magazineClip.position - this.transform.position).magnitude;
        }

        if (ovrGrabbable.isGrabbed && OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.2f)
        {
            if (distance > clipLimit)
            {
                // UnclipFromWeapon();
                Invoke("UnclipFromWeapon", 0.1f);
            }
            else
            {
                ClipToWeapon();
            }
        }


    }

    private void ClipToWeapon()
    {
        transform.parent = weaponBehaviour.gameObject.transform.GetChild(1).transform;
        transform.localPosition = new Vector3(0,0,0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        this.transform.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.GetComponent<Collider>().isTrigger = true;
        isClipped = true;
        clipSound.Play();

    }
    private void UnclipFromWeapon()
    {
        this.transform.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.GetComponent<Collider>().isTrigger = false;
        isClipped = false;
    }

    public void DiscardBullet()
    {
        if (bulletsCount > 1)
        {
            bulletsCount -= 1;
            bulletsCountDisplay.text = bulletsCount.ToString();
        }
        else
        {
            //bulletsCountDisplay.text = "Reload";
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "GrabVolumeBig" && OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.2f)
        {
            isClipped = false;
            clipSound.Play();
            transform.parent = GameObject.FindWithTag("Projectiles").transform;
        }
    }


}
