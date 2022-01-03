using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHP : MonoBehaviour
{
    public GameObject targetBody;//Alt Target
    public GameObject targetFoot;//MainTarget

    private void Awake()
    {
        Debug.Log(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp + "Awake/collusion");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Pistol")
        {
            targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp -= 1;
            Debug.Log(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp + "-1");

            if(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp <= 0)//Death
            {
                targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp = targetFoot.gameObject.GetComponent<TargetBehaviour>().HP;
                targetBody.GetComponent<MeshRenderer>().enabled = false;
                Invoke("enableTargetMesh", 3);
                Debug.Log(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp + "<=0");
            }
        }
    }

    private void enableTargetMesh()
    {
        targetBody.GetComponent<MeshRenderer>().enabled = true;
    }


}
