using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour
{

    public float speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; //transform.position takes the current position of the cactus and we will add to it a left vector which is normally has a value of 1 pointing in the left direction, we are going to multiply that by speed (so it will be a vector moving left at the magnitude of 10) and then we are going to multiply it by deltaTime (deltaTime is the amount of time it took to complete the last frame in seconds so it will be a fractional part of a second). So multiply vector3 by speed by deltaTime we are effectively saying we want to move left at 10 units per second. this will allow the game to play succesfully in different devices with different frame rates this ensures that the object will always move at a certain amount of units per second regardless of what the frame rate of the device is.
    }
}
