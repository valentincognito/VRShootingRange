using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineBehaviour : MonoBehaviour {

    public Text bulletsCountDisplay;
    public Text magazineCapacityDisplay;

    [SerializeField]
    private int magazineCapacity;
    [SerializeField]
    private int bulletsCount;

    private OVRGrabbable ovrGrabbable;

    private void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();

        magazineCapacityDisplay.text = magazineCapacity.ToString();
        bulletsCountDisplay.text = bulletsCount.ToString();
    }

    private void Update()
    {
        if (ovrGrabbable.isGrabbed)
        {
            Debug.Log("Grabbed");
        }
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
            transform.parent = GameObject.FindWithTag("Projectiles").transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "MagazineClip")
        {
            Debug.Log("true");
            //GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().isTrigger = false;
        }
    }


}
