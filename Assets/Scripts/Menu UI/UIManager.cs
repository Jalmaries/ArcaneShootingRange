using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject MainMenuUI;
    public GameObject PlayMenuUI;
    public GameObject SettingsMenuUI;

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

    public GameObject MusicOnOffTogle;
    public GameObject MusicVolumeSlider;

    public GameObject PlayerController;


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
        //Activate Polygon Game area
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






}
