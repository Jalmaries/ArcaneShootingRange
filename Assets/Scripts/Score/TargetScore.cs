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

    private int gameScore;

    private Text highScoreText;
    private Text GameScoreText;

    private void Start()
    {
        gameScore = Manager.GetComponent<Manager>().gameScore;
        highScoreText = Manager.GetComponent<Manager>().highScoreText;
        GameScoreText = Manager.GetComponent<Manager>().GameScoreText;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (head)
            {
                gameScore += 100;
                GameScoreText.text = gameScore.ToString();
                if(Manager.GetComponent<Manager>().highScore < gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = gameScore;
                    highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }
            else if (heart)
            {
                GameScoreText.text = gameScore.ToString();
                gameScore += 50;
                if (Manager.GetComponent<Manager>().highScore < gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = gameScore;
                    highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }
            else if (belly)
            {
                gameScore += 45;
                GameScoreText.text = gameScore.ToString();
                if (Manager.GetComponent<Manager>().highScore < gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = gameScore;
                    highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }
            else if (body)
            {
                gameScore += 5;
                GameScoreText.text = gameScore.ToString();
                if (Manager.GetComponent<Manager>().highScore < gameScore)
                {
                    Manager.GetComponent<Manager>().highScore = gameScore;
                    highScoreText.text = Manager.GetComponent<Manager>().highScore.ToString();
                }
            }

        }
    }
}
