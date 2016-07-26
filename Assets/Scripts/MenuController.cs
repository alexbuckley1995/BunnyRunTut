using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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
        Application.LoadLevel("Game"); //This method when called will use the LoadLevel method on the Application object to load our game scene. 
    }
}
