using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineBehaviour : MonoBehaviour {

    [SerializeField]
    private int magazineCapacity;
    [SerializeField]
	private int bulletsCount;

    public Text bulletsCountDisplay;

    public void DiscardBullet()
    {
        if (bulletsCount > 1)
        {
            bulletsCount -= 1;
            bulletsCountDisplay.text = bulletsCount.ToString();
        }
        else
        {
            bulletsCountDisplay.text = "Reload";
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "GrabVolumeBig" && OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) > 0.2f)
        {
            transform.parent = GameObject.FindWithTag("Projectiles").transform;
        }
    }

}
