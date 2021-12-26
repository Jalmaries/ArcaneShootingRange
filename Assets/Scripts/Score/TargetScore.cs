using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScore : MonoBehaviour
{
    //Note: Add this script to tagets and choose a bool for points. After adding to target, make sure to place "Manager" game object.

    public GameObject Manager;

    public bool head;
    public bool heart;
    public bool belly;
    public bool body;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (head)
            {
                Manager.GetComponent<Manager>().gameScore += 100;
                Manager.GetComponent<Manager>().GameScoreText.text = Manager.GetComponent<Manager>().gameScore.ToString();
                if(Manager.GetComponent<Manager>().highScore < Manager.GetComponent<Manager>().gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = Manager.GetComponent<Manager>().gameScore;
                    Manager.GetComponent<Manager>().highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }
            else if (heart)
            {
                Manager.GetComponent<Manager>().gameScore += 50;
                Manager.GetComponent<Manager>().GameScoreText.text = Manager.GetComponent<Manager>().gameScore.ToString();
                if (Manager.GetComponent<Manager>().highScore < Manager.GetComponent<Manager>().gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = Manager.GetComponent<Manager>().gameScore;
                    Manager.GetComponent<Manager>().highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }
            else if (belly)
            {
                Manager.GetComponent<Manager>().gameScore += 45;
                Manager.GetComponent<Manager>().GameScoreText.text = Manager.GetComponent<Manager>().gameScore.ToString();
                if (Manager.GetComponent<Manager>().highScore < Manager.GetComponent<Manager>().gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = Manager.GetComponent<Manager>().gameScore;
                    Manager.GetComponent<Manager>().highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }
            else if (body)
            {
                Manager.GetComponent<Manager>().gameScore += 5;
                Manager.GetComponent<Manager>().GameScoreText.text = Manager.GetComponent<Manager>().gameScore.ToString();
                if (Manager.GetComponent<Manager>().highScore < Manager.GetComponent<Manager>().gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = Manager.GetComponent<Manager>().gameScore;
                    Manager.GetComponent<Manager>().highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }

        }
    }

    private void OnDisable()//If target wont deactivate, place a gameObject to target, disable that object
    {
        Manager.GetComponent<Manager>().gameScore = 0;
    }


}
