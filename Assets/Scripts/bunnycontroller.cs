using UnityEngine;
using System.Collections;

public class bunnycontroller : MonoBehaviour {

    private Rigidbody2D myrigidbody;
    private Animator myAnim;
    public float bunnyjumpforce = 500f;

	// Use this for initialization
	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetButtonUp("Jump"))
        {
            myrigidbody.AddForce(transform.up * bunnyjumpforce);
        }
        myAnim.SetFloat("vVelocity", myrigidbody.velocity.y); //SetFloat method lets us set any float parameter we have set on the animator. I am calling the parameter vVelocity, and we tie it to the rigidbody's velocity in the y direction. The rigidbody is  controlling the physics. What this does in every frame update we are going to on the animator set its vVelocity parameter to the current velocity of the bunny as he is either falling down or jumping up. 
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) //If the collider boxes game object layer and see if the layermask is equal to the enemy layer mask. If it is the enemy we've hit then reload the level. 
        {
            Application.LoadLevel(Application.loadedLevel); //Application object is a global class that provides access to application functionality like loadlevel (which allows you to load a specific scene of the game). 
        }
    }
}
