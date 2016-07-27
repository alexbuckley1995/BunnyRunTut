using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject audioOnIcon;
    public GameObject audioOffIcon;


    // Use this for initialization
    void Start()
    {
        SetSoundState(); //When the MenuController starts up it will call the SetSoundState method which will then look at the current state of the muted preference and toggle the volume and icons accordingly. 

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //Check if the user has pressed the escape button on the title scene 
        {
            Application.Quit(); //Exit game
        }
    }

    public void StartGame() //Public method so we can call it, with void return type 
    {
        SceneManager.LoadScene("Game"); //This method when called will use the SceneManagemer.LoadScene package to load the game scene. 
    }

    public void ToggleSound() //Call this when we click the mute button
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)//If the muted value is currently 0. By default it will be set to 0. 

        {
            PlayerPrefs.SetInt("Muted", 1); //Then set it to 1

        }
        else //If the muted value is 1
        {
            PlayerPrefs.SetInt("Muted", 0); //Then set muted value to 0. 
        }
        SetSoundState(); //Calls the SetSoundState method after the btnMute has been clicked. So user toggles the button and this is remembered for future use and then turn the sound on and off based on the value of the muted option. 
    }

    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) ==0)
        {
            AudioListener.volume = 1; //Turns on the volumne
            audioOnIcon.SetActive(true);  //toggles unmute icon on
            audioOffIcon.SetActive(false); //toggles mute icon off
        }
        else 
        {
            AudioListener.volume = 0; //Turns volume off
            audioOnIcon.SetActive(false); //toggles unmute icon off
            audioOffIcon.SetActive(true); //toggles mute icon on

        }

      
    }
}
