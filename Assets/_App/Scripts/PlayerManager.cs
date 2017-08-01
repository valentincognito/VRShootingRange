using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool isArmed;
    public GameObject activeWeapon;

    private WeaponBehaviour weaponBehaviour;

    void Start()
    {
        weaponBehaviour = activeWeapon.GetComponent<WeaponBehaviour>();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            if (isArmed)
            {
                weaponBehaviour.Shoot();
            }
        }

        
    }
}
