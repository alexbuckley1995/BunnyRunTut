using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Importing a package from the subpackage called UI of the base UnityEngine package

public class bunnycontroller : MonoBehaviour {

    private Rigidbody2D myrigidbody;
    private Animator myAnim;
    public float bunnyjumpforce = 500f;
    private float bunnyHurtTime = -1; //This variable will store the time value when the bunny is collided with and then later on we will compare how much time has passed and if a certain amount of time has passed we can reload the level. 
    private Collider2D myCollider;
    public Text scoreText;
    private float startTime;

	// Use this for initialization
	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>(); //Grab the reference to the collider in the start method which is called when the gameObject (The bunny in this case) is first created 

        startTime = Time.time; //At the start of the game store the current time
	}

    // Update is called once per frame
    void Update()
    {

        if (bunnyHurtTime == -1) //When the game starts and whilst it is running it is going to do the button checking and animation setting (as when the game starts the bunnyHurtTime is set to -1), up until we actually collide with something (when we set bunnyHurtTime to a non -1 value). This if statement is to ensure that if the bunny is dead (i.e. bunnyHurtTime is not -1) then it cannot jump as we dont want that.
        {

            if (Input.GetButtonUp("Jump"))
            {
                myrigidbody.AddForce(transform.up * bunnyjumpforce);
            }
            myAnim.SetFloat("vVelocity", myrigidbody.velocity.y); //SetFloat method lets us set any float parameter we have set on the animator. I am calling the parameter vVelocity, and we tie it to the rigidbody's velocity in the y direction. The rigidbody is  controlling the physics. What this does in every frame update we are going to on the animator set its vVelocity parameter to the current velocity of the bunny as he is either falling down or jumping up. 

            scoreText.text = (Time.time - startTime).ToString("0.0"); //Set the text value that scoreText is displaying on screen equal to current game time minus the start time (so now we know how long the scene has been running in seconds). Because startTime is a float we have to convert it to a string and format that string into the format 0.0 (1dp)
        }
        else  //If bunnyHurtTime is not =-1 (i.e. the bunny has collided)
        {
            if (Time.time > bunnyHurtTime + 2) //If the current game time is 2 seconds after we collided then load the level
            {
                Application.LoadLevel(Application.loadedLevel); //Application object is a global class that provides access to application functionality like loadlevel (which allows you to load a specific scene of the game). 
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) //If the collider boxes game object layer and see if the layermask is equal to the enemy layer mask. If it is the enemy we've hit then reload the level. 
        {
            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>()) // Find any gameobject with the prefabSpawner added to them
            {
                spawner.enabled = false; //And disable those gameobjects
            }

            foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) //(FindObjectsOfType is a method avaliable on any game object) This asks Unity to find all objects in the current scene named MoveLeft so that will be any object with the  MoveLeft script (component) added to it.  Then loop through the list of objects that has been returned to us (this foreach loop returns an array of MoveLeft objects), and set the enabled flag of each MoveLeft object to false therefore disabling the cactus (just like you can untick the enabled button in the GUI) that will stop all the current cactus from moving accross the screen. 
            {
                moveLefter.enabled = false;
            }

            bunnyHurtTime = Time.time; //Set the bunnyHurtTime equal to the current time 
            myAnim.SetBool("bunnyHurt", true); //Set the bunnyHurt animation to true this will trigger the bunnyHurt animation.
            myrigidbody.velocity = Vector2.zero; //RigidBody controls the physics for the bunny this cancels out any motion it has. So when the bunny coliides set its velocity movement to zero and 
            myrigidbody.AddForce(transform.up * bunnyjumpforce); //Trigger it to jump up in the air
            myCollider.enabled = false; //Now we have the myCollider object in the start method and disable the collider 

        }
    }
}
