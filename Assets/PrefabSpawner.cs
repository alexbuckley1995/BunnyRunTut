using UnityEngine;
using System.Collections;

public class PrefabSpawner : MonoBehaviour {

    private float nextSpawn = 0; //this is a private variable internal to the class. This will hold the next point in time we want to spawn a cactus. 
    public Transform prefabToSpawn; //This will hold a reference to the prefab we want to spawn in this case the cactus prefab 
    public AnimationCurve spawnCurve;
    public float curveLengthInSeconds = 30f; //This is mapping the curve time length to 30 seconds (i.e. it takes 30 seconds for the curve to be completed from spawning a cactus one every second at the start to a cactus all the time at the end) 
    private float startTime;

    public float jitter = 0.25f; 

	// Use this for initialization
	void Start () { //This gets called when the prefabSpawner gets created
        startTime = Time.time; //Set the startTime to the current game time this lets us know how long it has been since the prefabSpawner has been created. 
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Time.time > nextSpawn ) //Time.time is the current game time is past our next spawn time, then spawn
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity); //passing into the instantiation method the prefab method I want to spawn (prefabToSpawn), current position (which is transform which is the game object this script is attached to which is our cactus spawn point game object) , and the rotation (because we don't want to rotate it so we write Quaternion.identity which is a zero value) so all together this instatiates the cactus 
                                                                                 //nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay); //This takes the current game time adds the spawnRate to it (which is by default 1 second) and then add an additional random amount of time between 0 and randomDelay

            float curvePos = (Time.time - startTime) / curveLengthInSeconds; //Calculate our position on a curve (between 0 and 1) by taking the current time and subtracting the startTime this tells us the fractional number of seconds that have passed since the prefab spanner was created and divide this by curveLengthInSeconds (curveLengthInSeconds =30) so this results in the calculation being the number of seconds that have passed divided by 30 and this gives us a value between 0 and 1 which is the position along the curve. 

            if (curvePos > 1f) //Because the curve is between 0 and 1 once we get past 30 seconds we will get a value greater than 1 so we want to cap that so this If statement is checking if we have gone past 1. The contents of this If statement will cause the game to go through the curve getting increasingly faster and then slow down again before getting faster and faster again. 
            {
                curvePos = 1f; //Set the curvePos =1.
                startTime = Time.time; //Reset the starttime to current time. 
            }

            nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + Random.Range(-jitter, jitter); //Now we have our position on the curve we need to calculate our next spawn time, this line makes the nextSpawn equal to the current time + spawnCurve (which is our animation curve we defined at the top) spawnCurve has a method on it called Evaluate (to which we pass in a value (which is the position on the curve, the horizontal axis of the graph ) we pass in curvePos which is the value we have calculcated which will be some value between 0 and 1. We add to this a random number (from -jitter(-0.25) to jitter +(0.25)) this will allow us to shrink or grow the spawn time by a random amount. 

        }


	}
}
