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
}
