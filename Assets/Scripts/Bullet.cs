using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100;
    public float bulletDamage = 50;

    private void Awake()
    {
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * bulletSpeed);
        Invoke("bulletDestroyer", 3);
    }

    private void OnCollisionEnter(Collision collision)// bullets needs to be destroyed when hit something
    {
        Destroy(gameObject);
    }

    private void bulletDestroyer()// bullets needs to be destroyed after some time 
    {
        Destroy(this.gameObject);
    }
}
