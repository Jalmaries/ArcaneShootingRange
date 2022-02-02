using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBackPistolWhenHitGround : MonoBehaviour
{

    public GameObject pistol;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == pistol)
        {
            pistol.gameObject.transform.position = new Vector3(60, 0.26f, -8.8f);
            pistol.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            pistol.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

    }




}
