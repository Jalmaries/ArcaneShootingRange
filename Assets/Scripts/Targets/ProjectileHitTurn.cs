using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitTurn : MonoBehaviour
{

    public float torqueValue;
    private Rigidbody rb;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            float turn = Input.GetAxis("Vertical");
            rb.AddTorque(transform.up * torqueValue * turn, ForceMode.Impulse);
        }
    }





}
