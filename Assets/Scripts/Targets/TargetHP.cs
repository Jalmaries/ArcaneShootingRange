using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetHP : MonoBehaviour
{

    public GameObject targetBody;//Alt Target
    public GameObject targetFoot;//MainTarget

    public AudioSource audioSourceSpawn;
    public AudioSource audioSourceMovement;

    public bool top = false;


    private void Awake()
    {
        Debug.Log(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp + "Awake/collusion");
        audioSourceSpawn = targetFoot.GetComponent<AudioSource>();
        audioSourceMovement = targetBody.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Sequence seq = DOTween.Sequence();

        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Pistol")
        {
            targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp -= 1;
            Debug.Log(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp + "-1");

            if(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp <= 0)//Death
            {
                targetBody.GetComponent<BoxCollider>().enabled = true;
                audioSourceMovement.Play();

                targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp = targetFoot.gameObject.GetComponent<TargetBehaviour>().HP;

                //targetBody.GetComponent<MeshRenderer>().enabled = false;
                if(top == false)
                {
                    seq
                        .Append(targetFoot.transform.DOMoveY(-8, 2).SetEase(Ease.Linear))
                        .Append(targetFoot.transform.DOMoveY(-1, 2).SetEase(Ease.Linear));
                    
                }
                else
                {
                    seq
                       .Append(targetFoot.transform.DOMoveY(12, 2).SetEase(Ease.Linear))
                       .Append(targetFoot.transform.DOMoveY(5, 2).SetEase(Ease.Linear));
                }
                
                

                Invoke("enableTargetMesh", 3);
                Debug.Log(targetFoot.gameObject.GetComponent<TargetBehaviour>().scriptOnlyHp + "<=0");

            }
        }
    }

    private void enableTargetMesh()
    {
        //targetBody.GetComponent<MeshRenderer>().enabled = true;

        targetBody.GetComponent<BoxCollider>().enabled = false;

        audioSourceSpawn.Play();
    }


}
