using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    /*Add:
     * in-game start, pause buttons
     * end game UI (will show score)
     * Bug Solving: Reset every (or necessary) values on app-quit or start to prevent bugs.
     * Bug: Score text resets but the value is not when new game starts
    */

    #region All UI


    #region Main UI's
    public GameObject MainMenuUI;
    public GameObject PlayMenuUI;
    public GameObject SettingsMenuUI;
    public GameObject PolygonMainMenuUI;
    public GameObject PolygonTimerUI;
    public GameObject ScoreUI;
    #endregion

    #region Turn Toggles
    public GameObject Snap15;
    public GameObject Snap30;
    public GameObject Snap45;
    public GameObject Snap60;
    public GameObject Snap90;

    public GameObject Smooth20;
    public GameObject Smooth30;
    public GameObject Smooth40;
    public GameObject Smooth50;
    public GameObject Smooth60;

    public GameObject SnapdegreeTogles;
    public GameObject SmoothDegreeTogles;
    

    public GameObject snapTurnTogle;
    public GameObject smoothTurnTogle;
    

    public GameObject snapTurnSelectedText;
    public GameObject smoothTurnSelectedText;
    #endregion

    #region Music Toggles
    public GameObject MusicOnOffTogle;
    public GameObject MusicVolumeSlider;
    #endregion

    #region Buttons
    public GameObject toMainMenuButton;
    public GameObject polygonReturnButton;
    #endregion

    public GameObject PlayerController;
    public GameObject XRRig;

    #region Polygon Area
    public GameObject polygonArea;
    //Timer
    public Text polygonGameCountdownTimerText;
    public int polygonGameCountdownValue;//Set in Editor
    private int polygongameCountdownValue;//Used for script only (will be equal to "polygonGameCountdownValue")
    //Targets
    public GameObject sphereTarget;
    //Guns
    //public GameObject GunRiffle;
    public GameObject PowdersPistol;

    private bool gameStartShot = false;
    #endregion

    //Score Manager
    //Playerprefs for save High Score value
    public int gameScore = 0;//Will increase while playing. Always return 0 when quting or restarting the polygon game.
    public int highScore;//High score. Will be shown in display as high score. Will be saved when quiting or finisihng the game.
    public Text GameScoreText;
    public Text highScoreText;

    private void Start()
    {
        //Time
        polygongameCountdownValue = polygonGameCountdownValue;
        polygonGameCountdownTimerText.text = polygongameCountdownValue.ToString();
        //Score
        if (PlayerPrefs.HasKey("High_Score"))
        {
            highScore = PlayerPrefs.GetInt("High_Score");
            highScoreText.text = PlayerPrefs.GetInt("High_Score").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("High_Score", 0);
            highScoreText.text = PlayerPrefs.GetInt("High_Score").ToString();
        }
        
        GameScoreText.text = gameScore.ToString();
        //highScoreText.text = highScore.ToString();
    }

    public void playButton()//when pressed play button
    {
        //Summary: when play button pressed, deactivate "Main Menu UI" then activate "Play Menu UI".

        PlayMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void settingsButton()//when pressed settings button button
    {
        //Summary: when settings button pressed, deactivate "Main Menu UI" then activate "Settings Menu UI".

        SettingsMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void creditsButton()//when pressed credits button (In Development!)
    {
        //Summary: when credits button pressed, deactivate "Main Menu UI" then activate "Credits Menu UI" (or screen).
    }

    public void quitButton()
    {
        //Summar: Quit from the app
        Application.Quit();
    }

    public void backToMainMenuButton()//when pressed "Main Menu" button
    {
        //Summary: when "Main Menu" button pressed, deactivate "(activated UI)" then activate "Main Menu UI".

        PlayMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void polygonButton()//when pressed polygon button (In Development)
    {
        //Summary: when Polygon button pressed, deactivate "Play Menu UI" then start The Game (Polygon).

        PlayMenuUI.SetActive(false);
        polygonArea.SetActive(true);
        XRRig.transform.position = new Vector3(60, 0, -10);//Change Location of Player XRRig (60, 0, -10) / (plane = 60, -1, 0 / scale = 8, 1, 4)

    }

    public void boxMachineButton()//when pressed "Box Machine" button (In Development)
    {
        //Summary: when Box Machine button pressed, deactivate "Play Menu UI" then start The Game (Box Machine).

        PlayMenuUI.SetActive(false);
        //Activate Box Machine Game area
    }

    public void SnapTurnTogle()//when pressed "Snap Turn" togle bool
    {
        //Summary: when "Snap Turn" togle pressed, activate "Snap Turn" togle, then deactivate "Smooth Turn" togle (Make deactivated toggles alpha value less then 1).

        PlayerController.GetComponent<BNG.PlayerRotation>().RotationType = BNG.RotationMechanic.Snap;
        SmoothDegreeTogles.SetActive(false);
        SnapdegreeTogles.SetActive(true);
        snapTurnSelectedText.SetActive(true);
        smoothTurnTogle.SetActive(true);
        smoothTurnSelectedText.SetActive(false);
        snapTurnTogle.SetActive(false);
        //Change background color
    }

    public void SmoothTurnTogle()//when pressed "Smooth Turn" togle bool
    {
        //Summary: when "Smooth Turn" togle pressed, activate "Smooth Turn" togle, then deactivate "Snap Turn" togle (Make deactivated toggles alpha value less then 1).

        PlayerController.GetComponent<BNG.PlayerRotation>().RotationType = BNG.RotationMechanic.Smooth;
        SmoothDegreeTogles.SetActive(true);
        SnapdegreeTogles.SetActive(false);
        smoothTurnSelectedText.SetActive(true);
        snapTurnTogle.SetActive(true);
        snapTurnSelectedText.SetActive(false);
        smoothTurnTogle.SetActive(false);
        //Change background color
    }

    public void MusicTogle()//when pressed "Music" togle bool (In Development)
    {
        //Summary: when Music togle pressed, activate "Music, if pressed again, make it deactive.

        //Activate Music if deactive, deactivate if active.
    }

    public void MusicSlide()//when slide "Music" slider (In Development)
    {
        //Summary: when Music slider changed by player, change the percentage of music volume. (Music will play only Music togle bool is active)

        //Change music volume percentage with slider
    }


    public void SnapTurnToggle15()//when pressed 15 degree togle
    {
        //Summary: When pressed snap 15 degree togle, change snap turning to 15. Disable other snap togle checks.
        /*
        Snap15.GetComponent<Toggle>().isOn = true;
        Snap30.GetComponent<Toggle>().isOn = false;
        Snap45.GetComponent<Toggle>().isOn = false;
        Snap60.GetComponent<Toggle>().isOn = false;
        Snap90.GetComponent<Toggle>().isOn = false;
        */


        PlayerController.GetComponent<BNG.PlayerRotation>().SnapRotationAmount = 15;
    }

    public void SnapTurnToggle30()//when pressed 30 degree togle
    {
        //Summary: When pressed snap 30 degree togle, change snap turning to 30. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SnapRotationAmount = 30;
    }

    public void SnapTurnToggle45()//when pressed 45 degree togle
    {
        //Summary: When pressed snap 45 degree togle, change snap turning to 45. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SnapRotationAmount = 45;
    }

    public void SnapTurnToggle60()//when pressed 60 degree togle
    {
        //Summary: When pressed snap 60 degree togle, change snap turning to 60. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SnapRotationAmount = 60;
    }

    public void SnapTurnToggle90()//when pressed 90 degree togle
    {
        //Summary: When pressed snap 90 degree togle, change snap turning to 90. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SnapRotationAmount = 90;
    }


    public void SmoothTurnToggle20()//when pressed 20 degree togle
    {
        //Summary: When pressed snap 20 degree togle, change smooth turning to 20. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SmoothTurnSpeed = 20;
    }

    public void SmoothTurnToggle30()//when pressed 30 degree togle
    {
        //Summary: When pressed snap 30 degree togle, change smooth turning to 30. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SmoothTurnSpeed = 30;
    }

    public void SmoothTurnToggle40()//when pressed 40 degree togle
    {
        //Summary: When pressed snap 40 degree togle, change smooth turning to 40. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SmoothTurnSpeed = 40;
    }

    public void SmoothTurnToggle50()//when pressed 50 degree togle
    {
        //Summary: When pressed snap 50 degree togle, change smooth turning to 50. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SmoothTurnSpeed = 50;
    }

    public void SmoothTurnToggle60()//when pressed 60 degree togle
    {
        //Summary: When pressed snap 60 degree togle, change smooth turning to 60. Disable other snap togle checks.

        PlayerController.GetComponent<BNG.PlayerRotation>().SmoothTurnSpeed = 60;
    }

    public void polygonSettingsButton()//when "Settings" button pressed in polygon area
    {
        //Summary: When pressed "Settings" button in polygon area from Polygon Main Menu, change location and size of the SettingsMenuUI.

        PolygonMainMenuUI.SetActive(false);
        SettingsMenuUI.transform.position = new Vector3(60, 1, -9);
        SettingsMenuUI.transform.localScale = new Vector3(0.005f, 0.005f, 1);
        SettingsMenuUI.SetActive(true);

        toMainMenuButton.SetActive(false);
        polygonReturnButton.SetActive(true);
    }

    public void PolygonReturnButton()//when "Return" button pressed in polygon area
    {
        //Summary: When pressed "Return" button in polygon area (SettingMenuUI) from Polygon area, activate Polygon Main Menu UI.

        SettingsMenuUI.SetActive(false);
        PolygonMainMenuUI.SetActive(true);
    }

    public void polygonToMainMenuButton()//when "Main Menu" button pressed in polygon area
    {
        //Summary: When pressed "Main Menu" button in polygon area from Polygon Main Menu, change location of the XRRig (To main area).

        SettingsMenuUI.transform.position = new Vector3(0, 0, 0.23f);
        SettingsMenuUI.transform.localScale = new Vector3(0.0018f, 0.0018f, 2);
        toMainMenuButton.SetActive(true);
        polygonReturnButton.SetActive(false);
        XRRig.transform.position = new Vector3(0, 0, -2);
        PlayMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
        polygonArea.SetActive(false);
    }

    public void polygonStartButton()//when "Start" button pressed in polygon area (In Development)
    {
        //Summary: When pressed "Start" button in polygon area from Polygon Main Menu, start the polygon game
        //Note: Game will start with first shot.

        PolygonMainMenuUI.SetActive(false);
        PolygonTimerUI.SetActive(true);
        //InvokeRepeating("polygonGameCountdownTime", 3, 1);//Function, wait, repeat value (Polygon Game Timer)

        //Guns
        PowdersPistol.SetActive(true);
        PowdersPistol.GetComponent<Rigidbody>().isKinematic = true;
        PowdersPistol.GetComponent<Rigidbody>().isKinematic = false;

        /*
        GunRiffle.SetActive(true);
        GunRiffle.GetComponent<Rigidbody>().isKinematic = true;
        GunRiffle.GetComponent<Rigidbody>().isKinematic = false;
        */

        //reset riffle ammo and animation
        //GunRiffle.GetComponent<BNG.RaycastWeapon>().InternalAmmo = 30;

        //Targets (add all targets here)
        sphereTarget.SetActive(true);
        
    }

    private void polygonGameCountdownTime()//when Polygon Game started in polygon area with first shot (In Development)
    {
        //Summary: When Polygon Game started with first shot, activate score, timer etc. Stop when timer reach zero

        polygongameCountdownValue -= 1;
        polygonGameCountdownTimerText.text = polygongameCountdownValue.ToString();
        if(polygongameCountdownValue <= 0)
        {
            CancelInvoke("polygonGameCountdownTime");
            polygongameCountdownValue = polygonGameCountdownValue;
            polygonGameCountdownTimerText.text = polygongameCountdownValue.ToString();
            //PolygonMainMenuUI.SetActive(true);
            Invoke("activateGameMenuUI", 2);//Calling 2 sec later to prevent accident cliks on UI
            PolygonTimerUI.SetActive(false);
            //disable all target, guns etc. and reset their position
            sphereTarget.SetActive(false);
            //targets will return start position from their script
            /*
            GunRiffle.SetActive(false);
            GunRiffle.transform.position = new Vector3(59.5f, -0.2f, -9);
            */
            PowdersPistol.SetActive(false);
            PowdersPistol.transform.position = new Vector3(60.5f, -0.2f, -9);
            //
            gameStartShot = false;//Reset first shot - game start value for next game
            //Score
            gameScore = 0;//Reset "gameScore" when game finished
            GameScoreText.text = gameScore.ToString();//Reset Score text when game finished
            PlayerPrefs.SetInt("High_Score", highScore);
        }
    }


    #endregion


    public void gameStartWithFirstShot()//Polygon Game will starts in polygon area with first shot
    {
        if (gameStartShot == false)
        {
            InvokeRepeating("polygonGameCountdownTime", 0, 1);//Function, wait, repeat value (Polygon Game Timer)
        }
        gameStartShot = true;
    }

    private void activateGameMenuUI()//called from "polygonCountdownTime" when Polygon Game ends (x second later)
    {
        PolygonMainMenuUI.SetActive(true);
    }

    //Score
    private void OnApplicationQuit()
    {
        gameScore = 0;//To prevent buggs. (If player quits the app while in-game, values must reset for next game)
        gameStartShot = false;//To prevent buggs. (If player quits the app while in-game, values must reset for next game)
        PlayerPrefs.SetInt("High_Score", highScore);
        Debug.Log(highScore);
        Debug.Log(PlayerPrefs.GetInt("High_Score"));
    }


    //(For Debug) Reset High Score
    public void resetHighScoreButton()
    {
        highScore = 0;
        highScoreText.text = highScore.ToString();
        PlayerPrefs.SetInt("High_Score", highScore);
        Debug.Log(highScore);
        Debug.Log(PlayerPrefs.GetInt("High_Score"));
    }

    private void Update()
    {
        //Debug.Log(gameScore);
    }
}
