using UnityEngine;
using System.Collections;

public class PrefabSpawner : MonoBehaviour {

    private float nextSpawn = 0; //this is a private variable internal to the class. This will hold the next point in time we want to spawn a cactus. 
    public Transform prefabToSpawn; //This will hold a reference to the prefab we want to spawn in this case the cactus prefab 
    public float spawnRate = 1; //Time in seconds between spawning our prefabs
    public float randomDelay = 1; //This will make cactus not spawn exactly at the spawn rate but instead the spawn rate plus some random delay

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Time.time > nextSpawn ) //Time.time is the current game time is past our next spawn time, then spawn
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity); //passing into the instantiation method the prefab method I want to spawn (prefabToSpawn), current position (which is transform which is the game object this script is attached to which is our cactus spawn point game object) , and the rotation (because we don't want to rotate it so we write Quaternion.identity which is a zero value)
            nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay); //This takes the current game time adds the spawnRate to it (which is by default 1 second) and then add an additional random amount of time between 0 and randomDelay
        }


	}
}
