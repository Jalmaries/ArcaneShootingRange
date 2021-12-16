using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoReload : MonoBehaviour
{
    public bool startTimer; //check if player shooting or not. If player not shooting, start timer for reload
    public float TimeForReload; //after this much time, gun will start to reload over time
    public float reloadPerSecond;//how much time needed for every projectile to reload into gun

    private float timeForReload;

    private void Start()
    {
        timeForReload = TimeForReload;
        startTimer = false;
    }


    private void Update()
    {
        if (startTimer)
        {
            timeForReload -= Time.deltaTime;
        }
        

        if (timeForReload <= 0 && this.gameObject.GetComponent<BNG.RaycastWeapon>().InternalAmmo < this.gameObject.GetComponent<BNG.RaycastWeapon>().MaxInternalAmmo)
        {
            this.gameObject.GetComponent<BNG.RaycastWeapon>().InternalAmmo += Time.deltaTime * reloadPerSecond;
        }
    }

    public void resetTimer()//player shooting
    {
        timeForReload = TimeForReload;//reset reload timer
    }

    public void StartTimerOnGrab()
    {
        startTimer = true;
    }

    public void StopTimerOnRelease()
    {
        startTimer = false;
        timeForReload = TimeForReload;
    }
}
