using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuesGunReloadArea : MonoBehaviour
{
    public GameObject enteredGun;

    private bool Control;

    public bool shootControl;

    public float timeBetweenReload;

    private void Update()
    {
        if (shootControl)
        {
            Invoke("reloadGun", 0);
        }
        
    }


    private void reloadGun()
    {
        
        if (enteredGun.GetComponent<GunScript>().currentAmmo < enteredGun.GetComponent<GunScript>().maxAmmo)
        {
            enteredGun.GetComponent<GunScript>().currentAmmo += 1;
        }
        

        if (Control)
        {
            Invoke("reloadGun", timeBetweenReload);
        }
    }

}
