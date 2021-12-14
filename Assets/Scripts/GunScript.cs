using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip fire;
    public AudioClip reload;
    public AudioClip noAmmo;

    public GameObject bullet;
    public GameObject fireSlot;

    public GameObject continuesGunReloadArea;

    public int maxAmmo = 10;
    public int currentAmmo;

    public TextMeshPro ammoCount;

    private bool readyToFire = true;
    public float timeBetweenShooting;// to decide how fast will gun shoot
    private bool stopFire = false;

    private float gunVector;

    private void Update()
    {
        /*
        if(Vector3.Angle(transform.up, Vector3.up) > 90 && currentAmmo < maxAmmo)
        {
            Reload();
        }
        */

        ammoCount.text = currentAmmo.ToString();
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Plane")
        {
            this.gameObject.transform.position = new Vector3((float)-1.5, (float)0.7, 0);
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

    }


    public void selected()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void unselected()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        stopFire = true;
    }


    public void fireInput()
    {
        stopFire = false;
        if (readyToFire)
        {
            Fire();
        }
    }


    public void Fire()
    {
        readyToFire = false;

        Invoke("shootControlVoid", 2);

        if (currentAmmo > 0)
        {
            CancelInvoke("shootControlVoid");
            continuesGunReloadArea.GetComponent<ContinuesGunReloadArea>().shootControl = false;
            Instantiate(bullet, fireSlot.transform.position, fireSlot.transform.rotation);
            currentAmmo -= 1;
            ammoCount.text = currentAmmo.ToString();
            audioSource.PlayOneShot(fire);
            
        }
        else
        {
            audioSource.PlayOneShot(noAmmo);
        }

        Invoke("ResetShot", timeBetweenShooting);
        Invoke("shootControlVoid", 1);
    }


    public void Reload()
    {
        currentAmmo = maxAmmo;
        audioSource.PlayOneShot(reload);
        ammoCount.text = currentAmmo.ToString();
    }

    private void ResetShot()
    {
        readyToFire = true;
        if (!stopFire)
        {
            Fire();
        }
    }

    public void StopFire()
    {
        stopFire = true;
    }


    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GunReloadArea")
        {
            Reload();
        }
    }
    */

    public void shootControlVoid()
    {
        continuesGunReloadArea.GetComponent<ContinuesGunReloadArea>().shootControl = true;
    }

}
